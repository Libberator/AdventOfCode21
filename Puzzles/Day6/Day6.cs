using System;
using System.Linq;
using System.Collections.Generic;

namespace Puzzles;

public class Day6 : Puzzle
{
    private readonly Dictionary<int, long> _data = new();
    public Day6(string path) : base(path) 
    { 
        var intArray = Array.ConvertAll(LoadFromFile().First().Split(','), int.Parse);
        for (int i = 0; i < 9; i++) {
            _data[i] = intArray.Count(f => f == i);
        }
    }

    public override long SolvePart1(bool useLong) => GetTotalAfterNDays(_data, 80);  // 391671
    public override long SolvePart2(bool useLong) => GetTotalAfterNDays(_data, 256);  // 1754000560399
    
    private static long GetTotalAfterNDays(Dictionary<int, long> data, int totalDays)
    {
        long[] fishTotals = data.Select(d => d.Value).ToArray();

        for (int i = 0; i < totalDays; i++) {
            fishTotals[(i + 7) % 9] += fishTotals[i % 9];
        }
        return fishTotals.Sum();
    }
}

/*
// Earlier working version using Queues, for reference.
    private static long GetTotalAfterNDays(Dictionary<int, long> data, int totalDays)
    {
        Queue<Wrapper<long>> fishTotals = new(9);
        for (int i = 0; i < 9; i++)
        {
            if(!data.TryGetValue(i, out long val)) val = 0L;
            fishTotals.Enqueue(new Wrapper<long>() { Value = val });
        }

        // Front of line (0) goes to back of the line (8), and adds itself to slot (6) too
        for (int i = 0; i < totalDays; i++) 
        {
            var zeroes = fishTotals.Dequeue();
            fishTotals.ElementAt(6).Value += zeroes.Value;
            fishTotals.Enqueue(zeroes);
        }

        return fishTotals.Select(f => f.Value).Sum();
    }

    private class Wrapper<T> where T : struct { public T Value { get; set; } }
*/