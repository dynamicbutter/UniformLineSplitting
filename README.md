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
var result = UniformLineSplitting.Split(
    "<color=\"green\">Practice sessions are up 17.6% today compared to the past week!",
    25,
    1,
    3,
    UniformLineSplitting.Western);

Assert.AreEqual(
    "<color=\"green\">Practice sessions are\nup 17.6% today compared\nto the past week!",
    result);

```
