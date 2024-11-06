# UniformLineSplitting
Find the most uniform way to split lines at word boundaries, ignoring tags, with various constraints.

## Syntax
```csharp
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

```

## Example
```csharp
int maxLineLength = 75;
var input = @"This extra-long paragraph was writtin to demonstrate how the `fmt(1)` program handles longer inputs. When testing inputs, you don't want them  be too short, nor too long, because the quality of the program can only be determined upon inspection of complex content. The quick brown fox jumps over the lazy dog. Congress shall make no law respecting an establishment of religion, or prohibiting the free exercise thereof; or abridging the freedom of speech, or of the press; or the right of the people peaceably to assemble, and to petition the Government for a redress of grievances.";
int minLineCount = input.Length / maxLineLength == 0 ? 1 : input.Length / maxLineLength;
int maxLineCount = 2 * minLineCount;
var result = UniformLineSplitting.Split(
    input, maxLineLength, minLineCount, maxLineCount, UniformLineSplitting.Western);
```

## Result
```
This extra-long paragraph was writtin to demonstrate how the `fmt(1)`
program handles longer inputs. When testing inputs, you don't want them
be too short, nor too long, because the quality of the program can only be
determined upon inspection of complex content. The quick brown fox jumps
over the lazy dog. Congress shall make no law respecting an establishment
of religion, or prohibiting the free exercise thereof; or abridging the
freedom of speech, or of the press; or the right of the people peaceably
to assemble, and to petition the Government for a redress of grievances.
```