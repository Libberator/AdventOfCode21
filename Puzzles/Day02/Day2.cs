using System.Collections.Generic;

namespace Puzzles;

public class Day2 : Puzzle
{
    private readonly List<(string, int)> _data = new();
    private const string Forward = "forward", Down = "down", Up = "up";
    private readonly char _delimiter = ' ';

    public Day2(string path) : base(path) 
    {
        foreach(var line in LoadFromFile())
        {
            var split = line.Split(_delimiter);
            _data.Add((split[0], int.Parse(split[1])));
        }
    }

    public override int SolvePart1()
    {
        var horiz = 0;
        var depth = 0;

        foreach (var movement in _data)
            switch (movement.Item1)
            {
                case Forward:
                    horiz += movement.Item2;
                    break;
                case Down:
                    depth += movement.Item2;
                    break;
                case Up:
                    depth -= movement.Item2;
                    break;
            }

        return horiz * depth;
    }

    public override int SolvePart2()
    {
        var horiz = 0;
        var depth = 0;
        var aim = 0;

        foreach (var movement in _data)
            switch (movement.Item1)
            {
                case Forward:
                    horiz += movement.Item2;
                    depth += aim * movement.Item2;
                    break;
                case Down:
                    aim += movement.Item2;
                    break;
                case Up:
                    aim -= movement.Item2;
                    break;
            }

        return horiz * depth;
    }
}