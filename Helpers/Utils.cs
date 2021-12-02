﻿using System;
using System.Diagnostics;

namespace AdventOfCode;

public static class Utils
{
    public static int[] ConvertToInts(this string[] data)
    {
        return Array.ConvertAll(data, s => int.Parse(s));
    }
}

/* Wrap whatever method you want to benchmark like:
using (var watch = new Watch("Time of this method")) 
{ // Some method } 
*/
public sealed class Watch : IDisposable
{
    private readonly Stopwatch _watch;
    private readonly string _name;

    public Watch(string name) {
        _name = name;
        _watch = Stopwatch.StartNew();
    }

    public void Dispose() {
        _watch.Stop();
        Console.WriteLine($"{_name}: {_watch.ElapsedMilliseconds}");
    }
}
