using System;
using System.Linq;

namespace Puzzles;

public class Day14 : Puzzle
{
    private readonly int[] _data;

    public Day14(string path) : base(path) => _data = Array.ConvertAll(LoadFromFile().First().Split(','), int.Parse);

    public override int SolvePart1()
    {
        return -1;
    }

    public override int SolvePart2()
    {
        return -1;
    }
}
