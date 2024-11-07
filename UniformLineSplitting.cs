using System.Collections.Generic;

public class UniformLineSplitting
{
    public struct Options
    {
        public string WordSep;          // Word seperator inserted into the result
        public string LineSep;          // Line seperator inserted into the result
        public string Seperators;       // List of word seperators used by search
        public int SearchRadius;        // How many characters from maxLineLength to search
        public List<TagDef> TagDefs;    // Invisible markup tag definitions (if any)
    }

    public struct TagDef
    {
        public char Start;
        public char End;
        public char Escape;
    }

    public static Options HtmlText = new() {
        WordSep = " ",
        LineSep = "\n",
        Seperators = " \r\n\t",
        TagDefs = new() { new() { Start = '<', End = '>', Escape = '\\' } },
        SearchRadius = 10
    };

    public static Options PlainText = new() {
        WordSep = " ",
        LineSep = "\n",
        Seperators = " \r\n\t",
        SearchRadius = 10
    };

    public static Options Defaults = PlainText;

    public struct WordAndTagData
    {
        public enum Types
        {
            None,
            Word,
            Tag,
            Sep,
        }
        public Types Type;
        public int Pos;
        public int Len;
    }

    public struct LayoutState
    {
        public int CurrentLen;
        public List<int> LineLens;
        public string Result;
        public int Index;
        public bool Aborted;
        public double SortMetric;
    }

    // Search for the most uniform way to split the lines at the seperators.
    // Only results that adhere to the min/max criteria are considered.  The result
    // that minimizes the standard deviation of the line lengths is returned.
    //
    // Returns a new string with the line seperators inserted, or an empty string if
    // the search criteria could not be met
    //
    // input - the input string to split
    // maxLineLength - the maximum line length allowed
    // minLineCount - the minimum number of lines to span
    // maxLineCount - the maximum number of lines to span
    // options - various details about the job
    public static string Split(
        string input,
        int maxLineLength,
        int minLineCount,
        int maxLineCount,
        Options options)
    {
        if (maxLineLength > 0 && minLineCount > 0 && maxLineCount >= minLineCount) {
            List<WordAndTagData> wordAndTagData = GetWordAndTagData(input, options);
            for (var i = minLineCount; i <= maxLineCount; i++) {
                List<LayoutState> accumulator = new();
                CreateLayouts(
                    input,
                    new() { LineLens = new() },
                    accumulator,
                    wordAndTagData,
                    maxLineLength,
                    i,
                    options);
                if (accumulator.Count > 0) {
                    return GetMostUniformLayout(accumulator).Result;
                }
            }
        }
        return "";
    }

    // Recursively create layouts bifurcating at the seperators from SearchRadius
    // up to the maxLineLength boundary
    public static void CreateLayouts(
        string input,
        LayoutState layoutState,
        List<LayoutState> accumulator,
        List<WordAndTagData> wordAndTagData,
        int maxLineLength,
        int maxLineCount,
        Options options)
    {
        int minLineLength = maxLineLength - options.SearchRadius;
        if (layoutState.Index < wordAndTagData.Count) {
            var d = wordAndTagData[layoutState.Index++];
            if (d.Type == WordAndTagData.Types.Tag) {
                layoutState.Result += input.Substring(d.Pos, d.Len);
            }
            else {
                if (d.Type == WordAndTagData.Types.Sep && layoutState.CurrentLen + d.Len >= minLineLength) {
                    LayoutState layoutState2 = layoutState;
                    layoutState2.LineLens = new();
                    layoutState2.LineLens.AddRange(layoutState.LineLens);
                    // Main path - end the line at this sep
                    layoutState.Result += options.LineSep;
                    layoutState.LineLens.Add(layoutState.CurrentLen);
                    layoutState.CurrentLen = 0;
                    if (layoutState2.CurrentLen + d.Len <= maxLineLength) {
                        // Bifurcation path - continue the line
                        layoutState2.CurrentLen += d.Len;
                        layoutState2.Result += input.Substring(d.Pos, d.Len);
                        CreateLayouts(
                            input,
                            layoutState2,
                            accumulator,
                            wordAndTagData,
                            maxLineLength,
                            maxLineCount,
                            options);
                    }
                }
                else {
                    layoutState.CurrentLen += d.Len;
                    layoutState.Result += input.Substring(d.Pos, d.Len);
                    if (layoutState.CurrentLen > maxLineLength) {
                        layoutState.Aborted = true;
                    }
                }
            }
            // Main path
            CreateLayouts(
                input,
                layoutState,
                accumulator,
                wordAndTagData,
                maxLineLength,
                maxLineCount,
                options);
        }
        else {
            if (layoutState.Aborted == false) {
                if (layoutState.CurrentLen > 0) {
                    layoutState.LineLens.Add(layoutState.CurrentLen);
                    layoutState.CurrentLen = 0;
                }
                if (layoutState.LineLens.Count <= maxLineCount) {
                    accumulator.Add(layoutState);
                }
            }
        }
    }

    // Return positions and lengths of tags, words, and seperators
    public static List<WordAndTagData> GetWordAndTagData(string input, Options options)
    {
        List<WordAndTagData> results = new()
        {
            { new() { Type = WordAndTagData.Types.None } }
        };
        int pos = 0;
        foreach (var c in input) {
            ProcessChar(results, c, pos, options);
            pos++;
        }
        for (var i = results.Count - 1; i >= 0; i--) {
            if (results[i].Type == WordAndTagData.Types.None) {
                results.RemoveAt(i);
            }
        }
        return results;
    }

    // Sort by layout uniformity
    public static void SortByUniformity(List<LayoutState> layoutStates)
    {
        StdDev(layoutStates);
        layoutStates.Sort(
            (a, b) => {
                if (a.SortMetric == b.SortMetric) {
                    return 0;
                }
                else if (a.SortMetric < b.SortMetric) {
                    return -1;
                }
                else {
                    return 1;
                }
            });
    }

    // Return the most uniform layout
    public static LayoutState GetMostUniformLayout(List<LayoutState> layoutStates)
    {
        var minIndex = 0;
        var minDev = double.MaxValue;
        for (var i = 0; i < layoutStates.Count; i++) {
            var stdDev = StdDev(layoutStates[i]);
            if (stdDev < minDev) {
                minDev = stdDev;
                minIndex = i;
            }
        }
        return layoutStates[minIndex];
    }

    // Compute stddev of each item for sorting
    static void StdDev(List<LayoutState> layoutStates)
    {
        for (var i = 0; i < layoutStates.Count; i++) {
            var ls = layoutStates[i];
            ls.SortMetric = StdDev(ls);
            layoutStates[i] = ls;
        }
    }

    static WordAndTagData.Types GetPriorType(List<WordAndTagData> wordAndTagData)
    {
        WordAndTagData.Types result = WordAndTagData.Types.None;
        for (var i = wordAndTagData.Count - 2; i >= 0; i--) {
            result = wordAndTagData[i].Type;
            if (result != WordAndTagData.Types.Tag) {
                break;
            }
        }
        return result;
    }

    static WordAndTagData.Types GetCharTypeForState(
        List<WordAndTagData> wordAndTagData, WordAndTagData.Types state, char c, Options options)
    {
        if (state == WordAndTagData.Types.Tag) {
            if (c == options.TagDefs[0].End) {
                return GetPriorType(wordAndTagData);
            }
            else {
                return WordAndTagData.Types.Tag;
            }
        }
        else {
            if (options.TagDefs != null && c == options.TagDefs[0].Start) {
                return WordAndTagData.Types.Tag;
            }
            else if (options.Seperators.Contains(c)) {
                return WordAndTagData.Types.Sep;
            }
            else {
                return WordAndTagData.Types.Word;
            }
        }
    }

    static void ProcessChar(
        List<WordAndTagData> wordAndTagData, char c, int pos, Options options)
    {
        var data = wordAndTagData[^1];
        var type = GetCharTypeForState(wordAndTagData, data.Type, c, options);
        if (data.Type == WordAndTagData.Types.None) {
            wordAndTagData[^1] =
                new WordAndTagData() {
                    Type = type,
                    Pos = pos,
                    Len = 1,
                };
        }
        else if (data.Type == WordAndTagData.Types.Tag) {
            data.Len++;
            wordAndTagData[^1] = data;
            if (c == options.TagDefs[0].End) {
                wordAndTagData.Add(
                    new() {
                        Type = WordAndTagData.Types.None,
                    });
            }
        }
        else {
            if (type == data.Type) {
                data.Len++;
                wordAndTagData[^1] = data;
            }
            else {
                wordAndTagData.Add(
                    new WordAndTagData() {
                        Type = type,
                        Pos = pos,
                        Len = 1,
                    });
            }
        }
    }

    static double StdDev(LayoutState layoutState)
    {
        return layoutState.LineLens.StdDev(layoutState.LineLens.Mean());
    }
}
