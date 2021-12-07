using System;
using System.Linq;

namespace Puzzles;

public class Day21 : Puzzle
{
    private readonly int[] _data;

    public Day21(string path) : base(path) => _data = Array.ConvertAll(LoadFromFile().First().Split(','), int.Parse);

    public override int SolvePart1()
    {
        return -1;
    }

    public override int SolvePart2()
    {
        return -1;
    }
}
