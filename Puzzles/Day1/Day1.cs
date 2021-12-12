using System;
using System.Linq;

namespace Puzzles;

public class Day1 : Puzzle
{
    private readonly int[] _data;
    public Day1(string path) : base(path) 
    { 
        _data = Array.ConvertAll(LoadFromFile().ToArray(), s => int.Parse(s));
    }

    public override int SolvePart1()
    {
        var previousNum = _data[0];
        var solution = 0;

        for (var i = 1; i < _data.Length; i++)
        {
            var currentNum = _data[i];
            if (currentNum > previousNum) solution++;
            previousNum = currentNum;
        }

        return solution;
    }

    public override int SolvePart2()
    {
        int[] window = new int[3] { _data[0], _data[1], _data[2] };
        var previousSum = window.Sum();

        var solution = 0;

        for (var i = 3; i < _data.Length; i++)
        {
            window[i % 3] = _data[i];
            var currentSum = window.Sum();
            if (currentSum > previousSum) solution++;
            previousSum = currentSum;
        }

        return solution;
    }

}