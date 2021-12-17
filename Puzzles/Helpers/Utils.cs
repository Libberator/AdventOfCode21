using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

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


    private static readonly Dictionary<int, int> _pascalLookup = new();

    // Pascal's Triangle: f(5) = 1 + 2 + 3 + 4 + 5 = 15 = n(n+1)/2
    public static int GetPascals(int input)
    {
        if(!_pascalLookup.TryGetValue(input, out int result)) 
        {
            result = (input * (input + 1)) >> 1;
            _pascalLookup.Add(input, result);
        }
        return result;
    }

    private static readonly Dictionary<int, int> _acceleratedSumLookup = new();

    // f(5) = 1 + 3 + 6 + 10 + 15 = 35 = n(n+1)(n+2)/6 = sequence 1, 4, 10, 20, 35, 56
    public static int GetAcceleratingSum(int input){
        if(!_acceleratedSumLookup.TryGetValue(input, out int result)) 
        {
            result = input * (input + 1) * (input + 2) / 6;
            _acceleratedSumLookup.Add(input, result);
        }
        return result;
    }

}

public static class Vector2Extension
{
    public static bool IsLateralTo(this Vector2 a, Vector2 b) => a.X == b.X || a.Y == b.Y;

    public static IEnumerable<Vector2> GetRange(this Vector2 from, Vector2 to)
    {
        do {
            yield return from;
            from.X += from.X < to.X ? 1 : from.X > to.X ? -1 : 0;
            from.Y += from.Y < to.Y ? 1 : from.Y > to.Y ? -1 : 0;
        } while (from != to);
        yield return to;
    }

    public static void Reset(this ref Vector2 v) => v = Vector2.Zero;
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
