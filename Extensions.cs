using System;
using System.Linq;
using System.Collections.Generic;

public static class Extensions {

    public static float Mean(this IEnumerable<int> values)
    {
        return (float)values.Average();
    }

    public static float StdDev(this IEnumerable<int> values, float mean)
    {
        return (float)Math.Sqrt(values.Average(v => Math.Pow(v - mean, 2)));
    }
}
