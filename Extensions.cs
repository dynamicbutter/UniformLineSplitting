using System;
using System.Collections.Generic;

public static class Extensions
{
    public static float Mean(this IEnumerable<int> values)
    {
        var sum = 0f;
        var count = 0;
        foreach (var v in values)
        {
            sum += v;
            count++;
        }
        return sum / count;
    }

    public static float StdDev(this IEnumerable<int> values, float mean)
    {
        var sum = 0.0;
        var count = 0;
        foreach (var v in values)
        {
            sum += Math.Pow(v - mean, 2);
            count++;
        }
        return (float)Math.Sqrt(sum / count);
    }

    public static double Mean(this IEnumerable<double> values)
    {
        var sum = 0.0;
        var count = 0;
        foreach (var v in values)
        {
            sum += v;
            count++;
        }
        return sum / count;
    }

    public static double StdDev(this IEnumerable<double> values, double mean)
    {
        var sum = 0.0;
        var count = 0;
        foreach (var v in values)
        {
            sum += Math.Pow(v - mean, 2);
            count++;
        }
        return Math.Sqrt(sum / count);
    }
}
