using System;
using System.Linq;
using System.Collections.Generic;

namespace Puzzles;

public class Day6 : Puzzle<Dictionary<int, int>>
{
    public Day6(string path) : base(path) { }
    public override Dictionary<int, int> ConvertData(IEnumerable<string> data)
    {
        Dictionary<int, int> numToQty = new();
        var intArray = Array.ConvertAll(data.First().Split(','), int.Parse);
        for (int i = 0; i < 7; i++) {
            int count = 0;
            if((count = intArray.Count(f => f == i)) != 0)
            {
                numToQty[i] = count;
            }
        }
        return numToQty;
    }

    public override int SolvePart1(Dictionary<int, int> data)
    {
        int totalDays = 80;
        
        long total = 0;
        foreach (var number in data.Keys) {
            total += GetTotalAfterNDays(number, totalDays) * data[number];
        }
        return Convert.ToInt32(total);  // 391671
    }
    public override int SolvePart2(Dictionary<int, int> data) => 0; // ignore this

    public override long SolvePart2(bool useLong) 
    {
        int totalDays = 256;

        long total = 0L;
        foreach (var number in _data.Keys) {
            total += GetTotalAfterNDays(number, totalDays) * _data[number];
        }
        return total;  // 1754000560399
    }

    private static long GetTotalAfterNDays(int startingNum, int totalDays)
    {
        Queue<Wrapper<long>> fishTotals = new(9);
        for (int i = 0; i < 9; i++) {
            fishTotals.Enqueue(i == startingNum ? 
            new Wrapper<long>(){Value = 1L} : 
            new Wrapper<long>(){Value = 0L});
        }

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