using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class UniformLineSplittingTests
{
    [Test]
    public void EmptyWordAndTagDataTest()
    {
        var d = UniformLineSplitting.GetWordAndTagData("", UniformLineSplitting.HtmlText);
        Assert.AreEqual(0, d.Count);
    }

    [Test]
    public void EndOnContinuation_WordAndTagDataTest()
    {
        var d = UniformLineSplitting.GetWordAndTagData(
            "<color=\"red\">You <size=50%>ranked</size> in the top <b>99.9%</b>!",
            UniformLineSplitting.HtmlText);
        Assert.AreEqual(17, d.Count);
        var i = 0;
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Tag, d[i].Type);
        Assert.AreEqual(0, d[i].Pos);
        Assert.AreEqual(13, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(13, d[i].Pos);
        Assert.AreEqual(3, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Sep, d[++i].Type);
        Assert.AreEqual(16, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Tag, d[++i].Type);
        Assert.AreEqual(17, d[i].Pos);
        Assert.AreEqual(10, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(27, d[i].Pos);
        Assert.AreEqual(6, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Tag, d[++i].Type);
        Assert.AreEqual(33, d[i].Pos);
        Assert.AreEqual(7, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Sep, d[++i].Type);
        Assert.AreEqual(40, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(41, d[i].Pos);
        Assert.AreEqual(2, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Sep, d[++i].Type);
        Assert.AreEqual(43, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(44, d[i].Pos);
        Assert.AreEqual(3, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Sep, d[++i].Type);
        Assert.AreEqual(47, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(48, d[i].Pos);
        Assert.AreEqual(3, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Sep, d[++i].Type);
        Assert.AreEqual(51, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Tag, d[++i].Type);
        Assert.AreEqual(52, d[i].Pos);
        Assert.AreEqual(3, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(55, d[i].Pos);
        Assert.AreEqual(5, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Tag, d[++i].Type);
        Assert.AreEqual(60, d[i].Pos);
        Assert.AreEqual(4, d[i].Len);
    }

    [Test]
    public void EndOnWord_WordAndTagDataTest()
    {
        var d = UniformLineSplitting.GetWordAndTagData(
            "<color=\"red\">You <size=50%>ranked</size> in the top <b>99.9%</b>!  mucker",
            UniformLineSplitting.HtmlText);
        Assert.AreEqual(19, d.Count);
        var i = 0;
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Tag, d[i].Type);
        Assert.AreEqual(0, d[i].Pos);
        Assert.AreEqual(13, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(13, d[i].Pos);
        Assert.AreEqual(3, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Sep, d[++i].Type);
        Assert.AreEqual(16, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Tag, d[++i].Type);
        Assert.AreEqual(17, d[i].Pos);
        Assert.AreEqual(10, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(27, d[i].Pos);
        Assert.AreEqual(6, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Tag, d[++i].Type);
        Assert.AreEqual(33, d[i].Pos);
        Assert.AreEqual(7, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Sep, d[++i].Type);
        Assert.AreEqual(40, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(41, d[i].Pos);
        Assert.AreEqual(2, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Sep, d[++i].Type);
        Assert.AreEqual(43, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(44, d[i].Pos);
        Assert.AreEqual(3, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Sep, d[++i].Type);
        Assert.AreEqual(47, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(48, d[i].Pos);
        Assert.AreEqual(3, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Sep, d[++i].Type);
        Assert.AreEqual(51, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Tag, d[++i].Type);
        Assert.AreEqual(52, d[i].Pos);
        Assert.AreEqual(3, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(55, d[i].Pos);
        Assert.AreEqual(5, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Tag, d[++i].Type);
        Assert.AreEqual(60, d[i].Pos);
        Assert.AreEqual(4, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(64, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Sep, d[++i].Type);
        Assert.AreEqual(65, d[i].Pos);
        Assert.AreEqual(2, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(67, d[i].Pos);
        Assert.AreEqual(6, d[i].Len);
    }

    [Test]
    public void EndOnSeperator_WordAndTagDataTest()
    {
        var d = UniformLineSplitting.GetWordAndTagData(
            "<color=\"red\">You <size=50%>ranked</size> in the top <b>99.9%</b>! mucker ",
            UniformLineSplitting.HtmlText);
        Assert.AreEqual(20, d.Count);
        var i = 0;
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Tag, d[i].Type);
        Assert.AreEqual(0, d[i].Pos);
        Assert.AreEqual(13, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(13, d[i].Pos);
        Assert.AreEqual(3, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Sep, d[++i].Type);
        Assert.AreEqual(16, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Tag, d[++i].Type);
        Assert.AreEqual(17, d[i].Pos);
        Assert.AreEqual(10, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(27, d[i].Pos);
        Assert.AreEqual(6, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Tag, d[++i].Type);
        Assert.AreEqual(33, d[i].Pos);
        Assert.AreEqual(7, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Sep, d[++i].Type);
        Assert.AreEqual(40, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(41, d[i].Pos);
        Assert.AreEqual(2, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Sep, d[++i].Type);
        Assert.AreEqual(43, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(44, d[i].Pos);
        Assert.AreEqual(3, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Sep, d[++i].Type);
        Assert.AreEqual(47, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(48, d[i].Pos);
        Assert.AreEqual(3, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Sep, d[++i].Type);
        Assert.AreEqual(51, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Tag, d[++i].Type);
        Assert.AreEqual(52, d[i].Pos);
        Assert.AreEqual(3, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(55, d[i].Pos);
        Assert.AreEqual(5, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Tag, d[++i].Type);
        Assert.AreEqual(60, d[i].Pos);
        Assert.AreEqual(4, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(64, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Sep, d[++i].Type);
        Assert.AreEqual(65, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Word, d[++i].Type);
        Assert.AreEqual(66, d[i].Pos);
        Assert.AreEqual(6, d[i].Len);
        Assert.AreEqual(UniformLineSplitting.WordAndTagData.Types.Sep, d[++i].Type);
        Assert.AreEqual(72, d[i].Pos);
        Assert.AreEqual(1, d[i].Len);
    }

    [Test]
    public void CreateLayoutsTest_24_3()
    {
        var maxLineLength = 24;
        var maxLines = 3;
        List<UniformLineSplitting.LayoutState> layouts = new();
        var tmproText = "Practice sessions are up 17.6% today compared to the past week!";
        var wordAndTagData = UniformLineSplitting.GetWordAndTagData(tmproText, UniformLineSplitting.HtmlText);
        UniformLineSplitting.CreateLayouts(
            tmproText,
            new() { LineLens = new() },
            layouts,
            wordAndTagData,
            maxLineLength,
            maxLines,
            UniformLineSplitting.HtmlText);
        Debug.Log($"{layouts.Count} layouts");
        UniformLineSplitting.SortByUniformity(layouts);
        foreach (var layout in layouts) {
            var text = "";
            foreach (var l in layout.LineLens) {
                text += $"{l} ";
            }
            Debug.Log($"{text}: {layout.Result}");
        }
        Assert.AreEqual(3, layouts.Count);
        Assert.AreEqual(
            "Practice sessions are\nup 17.6% today compared\nto the past week!",
            layouts[0].Result);
    }

    [Test]
    public void CreateLayoutsTest_23_3()
    {
        var maxLineLength = 23;
        var maxLines = 3;
        List<UniformLineSplitting.LayoutState> layouts = new();
        var tmproText = "Practice sessions are up 17.6% today compared to the past week!";
        var wordAndTagData = UniformLineSplitting.GetWordAndTagData(tmproText, UniformLineSplitting.HtmlText);
        UniformLineSplitting.CreateLayouts(
            tmproText,
            new() { LineLens = new() },
            layouts,
            wordAndTagData,
            maxLineLength,
            maxLines,
            UniformLineSplitting.HtmlText);
        Debug.Log($"{layouts.Count} layouts");
        UniformLineSplitting.SortByUniformity(layouts);
        foreach (var layout in layouts) {
            var text = "";
            foreach (var l in layout.LineLens) {
                text += $"{l} ";
            }
            Debug.Log($"{text}: {layout.Result}");
        }
        Assert.AreEqual(1, layouts.Count);
        Assert.AreEqual(
            "Practice sessions are\nup 17.6% today compared\nto the past week!",
            layouts[0].Result);
    }

    [Test]
    public void CreateLayoutsTest_22_3()
    {
        var maxLineLength = 22;
        var maxLines = 3;
        List<UniformLineSplitting.LayoutState> layouts = new();
        var tmproText = "Practice sessions are up 17.6% today compared to the past week!";
        var wordAndTagData = UniformLineSplitting.GetWordAndTagData(tmproText, UniformLineSplitting.HtmlText);
        UniformLineSplitting.CreateLayouts(
            tmproText,
            new() { LineLens = new() },
            layouts,
            wordAndTagData,
            maxLineLength,
            maxLines,
            UniformLineSplitting.HtmlText);
        Debug.Log($"{layouts.Count} layouts");
        UniformLineSplitting.SortByUniformity(layouts);
        foreach (var layout in layouts) {
            var text = "";
            foreach (var l in layout.LineLens) {
                text += $"{l} ";
            }
            Debug.Log($"{text}: {layout.Result}");
        }
        Assert.AreEqual(0, layouts.Count);
    }

    [Test]
    public void CreateLayoutsTest_20_4()
    {
        var maxLineLength = 20;
        var maxLines = 4;
        var options = UniformLineSplitting.HtmlText;
        options.SearchRadius = 12;
        List<UniformLineSplitting.LayoutState> layouts = new();
        var tmproText = "Practice sessions are up 17.6% today compared to the past week!";
        var wordAndTagData = UniformLineSplitting.GetWordAndTagData(tmproText, UniformLineSplitting.HtmlText);
        UniformLineSplitting.CreateLayouts(
            tmproText,
            new() { LineLens = new() },
            layouts,
            wordAndTagData,
            maxLineLength,
            maxLines,
            options);
        Debug.Log($"{layouts.Count} layouts");
        UniformLineSplitting.SortByUniformity(layouts);
        foreach (var layout in layouts) {
            var text = "";
            foreach (var l in layout.LineLens) {
                text += $"{l} ";
            }
            Debug.Log($"{text}: {layout.Result}");
        }
        Assert.AreEqual(7, layouts.Count);
        Assert.AreEqual(
            "Practice sessions\nare up 17.6%\ntoday compared to\nthe past week!",
            layouts[0].Result);
    }

    [Test]
    public void CreateLayoutsTest_20_4_Tags()
    {
        var maxLineLength = 20;
        var maxLines = 4;
        var options = UniformLineSplitting.HtmlText;
        options.SearchRadius = 12;
        List<UniformLineSplitting.LayoutState> layouts = new();
        var tmproText = "<color=\"green\">Prac<b>t</b><b></b>ice <b></b><b></b><b></b>sessions <b></b><b></b><b></b>are up 17.6<b>%</b> today compared to<b></b><b></b> the past week!";
        var wordAndTagData = UniformLineSplitting.GetWordAndTagData(tmproText, UniformLineSplitting.HtmlText);
        UniformLineSplitting.CreateLayouts(
            tmproText,
            new() { LineLens = new() },
            layouts,
            wordAndTagData,
            maxLineLength,
            maxLines,
            options);
        Debug.Log($"{layouts.Count} layouts");
        UniformLineSplitting.SortByUniformity(layouts);
        foreach (var layout in layouts) {
            var text = "";
            foreach (var l in layout.LineLens) {
                text += $"{l} ";
            }
            Debug.Log($"{text}: {layout.Result}");
        }
        Assert.AreEqual(7, layouts.Count);
        Assert.AreEqual(
            "<color=\"green\">Prac<b>t</b><b></b>ice <b></b><b></b><b></b>sessions\n" +
            "<b></b><b></b><b></b>are up 17.6<b>%</b>\n" +
            "today compared to<b></b><b></b>\n" +
            "the past week!",
            layouts[0].Result);
    }

    [Test]
    public void UniformlySplitLinesTest()
    {
        var result = UniformLineSplitting.Split(
            "<color=\"green\">Practice sessions are up 17.6% today compared to the past week!<this is a long tag full of words and spaces>",
            25, 1, 3, UniformLineSplitting.HtmlText);
        Assert.AreEqual(
            "<color=\"green\">Practice sessions are\nup 17.6% today compared\nto the past week!<this is a long tag full of words and spaces>",
            result);
    }

    [Test]
    public void UniformlySplitLinesWithoutTagsTest()
    {
        var input = "<color=\"green\">Practice sessions are up 17.6% today compared to the past week!<this is a long tag full of words and spaces>";
        var result = UniformLineSplitting.Split(
            input, 40, 1, 4, UniformLineSplitting.PlainText);
        Assert.AreEqual(
            "<color=\"green\">Practice sessions are\nup 17.6% today compared to the past\nweek!<this is a long tag full of words\nand spaces>",
            result);
    }

    [Test]
    public void UnixFormatDocTest()
    {
        int maxLineLength = 75;
        var input = @"This extra-long paragraph was writtin to demonstrate how the `fmt(1)` program handles longer inputs. When testing inputs, you don't want them  be too short, nor too long, because the quality of the program can only be determined upon inspection of complex content. The quick brown fox jumps over the lazy dog. Congress shall make no law respecting an establishment of religion, or prohibiting the free exercise thereof; or abridging the freedom of speech, or of the press; or the right of the people peaceably to assemble, and to petition the Government for a redress of grievances.";
        int minLineCount = input.Length / maxLineLength;
        int maxLineCount = 2 * minLineCount;
        var result = UniformLineSplitting.Split(
            input, maxLineLength, minLineCount, maxLineCount, UniformLineSplitting.HtmlText);
        Assert.AreEqual(
@"This extra-long paragraph was writtin to demonstrate how the `fmt(1)`
program handles longer inputs. When testing inputs, you don't want them
be too short, nor too long, because the quality of the program can only be
determined upon inspection of complex content. The quick brown fox jumps
over the lazy dog. Congress shall make no law respecting an establishment
of religion, or prohibiting the free exercise thereof; or abridging the
freedom of speech, or of the press; or the right of the people peaceably
to assemble, and to petition the Government for a redress of grievances.",
            result);
        // using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter("/tmp/UnixFormatDocTest.txt")) {
        //     outputFile.WriteLine(result);
    }
}
