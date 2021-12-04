using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Utilities;

public static class Utils
{
    public static int[] ConvertToInts(this string[] data)
    {
        return Array.ConvertAll(data, s => int.Parse(s));
    }

    public static V? GetValueOrDefault<K, V>(this IDictionary<K,V> dict, K key, V? defVal)
    {
        return dict.TryGetValue(key, out V? value) ? value : defVal;
    }

}

// this will grow as certain puzzles require it