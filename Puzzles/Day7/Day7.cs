using System;
using System.Linq;
using System.Collections.Generic;

namespace Puzzles;

public class Day7 : Puzzle
{
    private readonly int[] _data;

    public Day7(string path) : base(path) => _data = Array.ConvertAll(LoadFromFile().ToArray().First().Split(','), int.Parse);

    public override int SolvePart1()
    {
        int lowestSum = int.MaxValue;

        for (int i = 0; i < _data.Length; i++)
        {
            var sum = GetFuelCostAtSpot(_data, i);
            if (sum < lowestSum){
                lowestSum = sum;
            }
        }
        return lowestSum;
    }

    public override int SolvePart2()
    {
        int lowestSum = int.MaxValue;

        for (int i = 0; i < _data.Length; i++)
        {
            var sum = GetFuelCostAtSpot(_data, i, true);
            if (sum < lowestSum){
                lowestSum = sum;
            }
        }
        return lowestSum;
    }

    private int GetFuelCostAtSpot(int[] data, int spot, bool part2 = false)
    {
        int sum = 0;
        for (int i = 0; i < data.Length; i++)
        {
            int diff = Math.Abs(spot - data[i]);
            sum += part2 ? GetPascals(diff) : diff;
        }
        return sum;
    }

    private readonly Dictionary<int, int> _lookupTable = new();

    // classic Pascal's Triangle
    private int GetPascals(int input)
    {
        if(!_lookupTable.TryGetValue(input, out int result))
        {
            result = (input * (input + 1)) >> 1;  // 0.5f * n * (n + 1)
            _lookupTable[input] = result;
        }
        return result;
    }
}
