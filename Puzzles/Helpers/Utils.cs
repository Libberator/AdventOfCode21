using System;
using System.Diagnostics;

namespace Utilities;

public static class Utils
{
    public static int[] ConvertToInts(this string[] data)
    {
        return Array.ConvertAll(data, s => int.Parse(s));
    }
}

// this will grow as certain puzzles require it