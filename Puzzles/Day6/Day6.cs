using System;
using System.Linq;
using System.Collections.Generic;

namespace Puzzles;

public class Day6 : Puzzle<Dictionary<int, long>>
{
    public Day6(string path) : base(path) { }
    public override Dictionary<int, long> ConvertData(IEnumerable<string> data)
    {
        Dictionary<int, long> numToQty = new();
        var intArray = Array.ConvertAll(data.First().Split(','), int.Parse);
        for (int i = 0; i < 7; i++) {
            long count = 0;
            if((count = intArray.Count(f => f == i)) != 0)
            {
                numToQty[i] = count;
            }
        }
        return numToQty;
    }

    public override int SolvePart2(Dictionary<int, long> data) => 0; // no-op. ignore
    public override int SolvePart1(Dictionary<int, long> data) => (int)GetTotalAfterNDays(_data, 80); // 391671
    public override long SolvePart2(bool useLong) => GetTotalAfterNDays(_data, 256); // 1754000560399

    private static long GetTotalAfterNDays(Dictionary<int, long> data, int totalDays)
    {
        Queue<Wrapper<long>> fishTotals = new(9);
        for (int i = 0; i < 9; i++) {
            fishTotals.Enqueue( data.TryGetValue(i, out long val) ? 
            new Wrapper<long>(){Value = val } : 
            new Wrapper<long>(){Value = 0L});
        }

        // Front of line (0) goes to back of the line (8), and adds itself to slot (6) too
        for (int i = 0; i < totalDays; i++) {
            var zeroes = fishTotals.Dequeue();
            fishTotals.ElementAt(6).Value += zeroes.Value;
            fishTotals.Enqueue(zeroes);
        }

        long subTotal = 0;
        for(int i = 0; i < 9; i++) {
            subTotal += fishTotals.Dequeue().Value;
        }
        return subTotal;
    }

    private class Wrapper<T> { public T Value { get; set; } }
}