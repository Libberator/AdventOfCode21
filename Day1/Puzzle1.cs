using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode;

public class Puzzle1 : Puzzle<int[]>
{
    public override void Init(IEnumerable<string> data)
    {
        _data = Array.ConvertAll(data.ToArray(), s => int.Parse(s));
    }

    public override int SolvePart1()
    {
        int previousNum = _data[0];
        int solution = 0;

        for (int i = 1; i < _data.Length; i++)
        {
            int currentNum = _data[i];
            if (currentNum > previousNum)
            {
                solution++;
            }
            previousNum = currentNum;
        }
        return solution;
    }

    public override int SolvePart2()
    {
        int[] window = new int[3] { _data[0], _data[1], _data[2] };
        int previousSum = window.Sum();

        int solution = 0;

        for (int i = 3; i < _data.Length; i++)
        {
            window[i % 3] = _data[i];
            int currentSum = window.Sum();
            if (currentSum > previousSum)
            {
                solution++;
            }
            previousSum = currentSum;
        }
        return solution;
    }
}