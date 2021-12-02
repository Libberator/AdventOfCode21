using System.Collections.Generic;

namespace AdventOfCode;
public class Puzzle2 : Puzzle<List<(string, int)>>
{
    private readonly char _delimiter = ' ';
    private const string FORWARD = "forward";
    private const string DOWN = "down";
    private const string UP = "up";

    public override void Init(IEnumerable<string> data)
    {
        _data = new List<(string, int)>();
        foreach(var s in data)
        {
            var split = s.Split(_delimiter);
            _data.Add((split[0], int.Parse(split[1])));
        }
    }

    public override int SolvePart1()
    {
        int horiz = 0;
        int depth = 0;

        foreach(var order in _data)
        {
            switch (order.Item1)
            {
                case FORWARD:
                    horiz += order.Item2;
                    break;
                case DOWN:
                    depth += order.Item2;
                    break;
                case UP:
                    depth -= order.Item2;
                    break;
            }
        }
     
        return horiz * depth;
    }

    public override int SolvePart2()
    {
        int horiz = 0;
        int depth = 0;
        int aim = 0;

        foreach(var order in _data)
        {
            switch (order.Item1)
            {
                case FORWARD:
                    horiz += order.Item2;
                    depth += aim * order.Item2;
                    break;
                case DOWN:
                    aim += order.Item2;
                    break;
                case UP:
                    aim -= order.Item2;
                    break;
            }
        }
     
        return horiz * depth;
    }
}