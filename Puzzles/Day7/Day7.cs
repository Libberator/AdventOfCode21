using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Puzzles;

public class Day7 : Puzzle
{
    private readonly int[] _data;

    public Day7(string path) : base(path) => _data = Array.ConvertAll(LoadFromFile().ToArray().First().Split(','), int.Parse);

    public override int SolvePart1()
    {
        int medianValue = GetMedian(_data);  // median: 342
        var fuelCost = GetFuelCostAtSpot(_data, medianValue);

        if (_data.Length % 2 == 0) {  // there are 2 "medians" if it's even
            var otherFuelCost = GetFuelCostAtSpot(_data, medianValue - 1);
            if (otherFuelCost < fuelCost) {
                return otherFuelCost;
            }
        }
        return fuelCost;  // 325528
    }

    public override int SolvePart2()
    {
        int meanValue = GetMean(_data);
        var fuelCost = GetFuelCostAtSpot(_data, meanValue, true); // floor
        var fuelCost2 = GetFuelCostAtSpot(_data, meanValue+1, true); // ceiling

        return Math.Min(fuelCost, fuelCost2);  // 85015836
    }

    private static int GetMedian(int[] data) => data.OrderBy(x => x).ElementAt(data.Length / 2);
    private static int GetMean(int[] data) => data.Sum() / data.Length; // Don't do rounding. Results aren't symmetrical or parabolic

    private int GetFuelCostAtSpot(int[] data, int spot, bool part2 = false)
    {
        int sum = 0;
        for (int i = 0; i < data.Length; i++) {
            int diff = Math.Abs(spot - data[i]);
            sum += part2 ? GetPascals(diff) : diff;
        }
        return sum;
    }

    private readonly Dictionary<int, int> _lookupTable = new();

    // classic Pascal's Triangle
    private int GetPascals(int input)
    {
        if(!_lookupTable.TryGetValue(input, out int result)) {
            result = (input * (input + 1)) >> 1;  // 0.5f * n * (n + 1)
            _lookupTable[input] = result;
        }
        return result;
    }
}
