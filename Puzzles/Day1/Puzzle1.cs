using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles;

public class Puzzle1 : PuzzleBase<int[]>
{
    public override int[] Convert(IEnumerable<string> data)
    {
        return Array.ConvertAll(data.ToArray(), s => int.Parse(s));
    }

    public override int SolvePart1(int[] data)
    {
        var previousNum = data[0];
        var solution = 0;

        for (var i = 1; i < data.Length; i++)
        {
            var currentNum = data[i];
            if (currentNum > previousNum) solution++;
            previousNum = currentNum;
        }

        return solution;
    }

    public override int SolvePart2(int[] data)
    {
        int[] window = new int[3] { data[0], data[1], data[2] };
        var previousSum = window.Sum();

        var solution = 0;

        for (var i = 3; i < data.Length; i++)
        {
            window[i % 3] = data[i];
            var currentSum = window.Sum();
            if (currentSum > previousSum) solution++;
            previousSum = currentSum;
        }

        return solution;
    }
}