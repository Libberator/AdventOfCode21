using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Utilities;

public static class Utils
{
    public static void AddToOrCreate<K>(this IDictionary<K, long> dict, K key, long val)
    {
        if(dict.ContainsKey(key)) {
            dict[key] += val;
        }
        else{
            dict.Add(key, val);
        }
    }

    public static int[] ConvertToInts(this string[] data)
    {
        return Array.ConvertAll(data, s => int.Parse(s));
    }

    public static V? GetValueOrDefault<K, V>(this IDictionary<K,V> dict, K key, V? defVal)
    {
        return dict.TryGetValue(key, out V? value) ? value : defVal;
    }

    public static IEnumerable<T> RemoveDuplicates<T>(this IEnumerable<T> source)
    {
        List<T> uniques = new();
        foreach (T item in source)
        {
            if (!uniques.Contains(item)) uniques.Add(item);
        }
        return uniques;
    }

    public static int BinaryToInt(string s) => Convert.ToInt32(s, 2);
    public static long BinaryToLong(string s) => Convert.ToInt64(s, 2);


    public static string Slice(this string source, int start, int end)
    {
        if (end < 0)  // Keep this for negative end support
        {
            end = source.Length + end;
        }
        int len = end - start;
        return source.Substring(start, len);
    }
}

public sealed class Watch : IDisposable {
    private readonly string _text;
    private readonly Stopwatch _watch;

    public Watch(string text) {
        _text = text;
        _watch = Stopwatch.StartNew();
    }
    
    public void Dispose() {
        _watch.Stop();
        Console.WriteLine($"{_text}: {_watch.ElapsedMilliseconds}ms");
    }
}
