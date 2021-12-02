using System.Collections.Generic;

namespace Puzzles;

public class Puzzle2 : Puzzle<List<(string, int)>>
{
    private const string Forward = "forward";
    private const string Down = "down";
    private const string Up = "up";
    private readonly char _delimiter = ' ';

    public override List<(string, int)> Convert(IEnumerable<string> data)
    {
        var convertedData = new List<(string, int)>();
        foreach (var s in data)
        {
            var split = s.Split(_delimiter);
            convertedData.Add((split[0], int.Parse(split[1])));
        }
        return convertedData;
    }

    public override int SolvePart1(List<(string, int)> data)
    {
        var horiz = 0;
        var depth = 0;

        foreach (var order in data)
            switch (order.Item1)
            {
                case Forward:
                    horiz += order.Item2;
                    break;
                case Down:
                    depth += order.Item2;
                    break;
                case Up:
                    depth -= order.Item2;
                    break;
            }

        return horiz * depth;
    }

    public override int SolvePart2(List<(string, int)> data)
    {
        var horiz = 0;
        var depth = 0;
        var aim = 0;

        foreach (var order in data)
            switch (order.Item1)
            {
                case Forward:
                    horiz += order.Item2;
                    depth += aim * order.Item2;
                    break;
                case Down:
                    aim += order.Item2;
                    break;
                case Up:
                    aim -= order.Item2;
                    break;
            }

        return horiz * depth;
    }
}