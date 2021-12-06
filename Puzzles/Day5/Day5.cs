using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections.Concurrent;

namespace Puzzles;

public class Day5 : Puzzle<List<(Vector2 , Vector2)>>
{
    private const string Arrow = " -> ";
    private const char Delimiter = ',';

    public Day5(string path) : base(path) { }

    public override List<(Vector2, Vector2)> ConvertData(IEnumerable<string> data)
    {
        var result = new List<(Vector2, Vector2)>();
        foreach (string line in data)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var split = line.Split(Arrow, StringSplitOptions.TrimEntries);
            var from = split[0].Split(Delimiter).Select(int.Parse).ToArray();
            var to = split[1].Split(Delimiter).Select(int.Parse).ToArray();
            result.Add((new Vector2(from[0], from[1]), new Vector2(to[0], to[1])));
        }
        return result;
    }

    public override int SolvePart1(List<(Vector2, Vector2)> data)
    {
        var spotsHit = new ConcurrentDictionary<Vector2, bool>();
        Parallel.ForEach(data.Where(pair => pair.Item1.IsLateralTo(pair.Item2)), item =>
        {
            foreach(var point in item.Item1.GetRange(item.Item2))
            {
                spotsHit[point] = spotsHit.ContainsKey(point);
            }
        });
        return spotsHit.Count(c => c.Value);  // 6710
    }

    public override int SolvePart2(List<(Vector2, Vector2)> data)
    {
        var spotsHit = new ConcurrentDictionary<Vector2, bool>();
        Parallel.ForEach(data, item =>
        {
            foreach(var point in item.Item1.GetRange(item.Item2))
            {
                spotsHit[point] = spotsHit.ContainsKey(point);
            }
        });
        return spotsHit.Count(c => c.Value); // 20121
    }
}

public static class Vector2Extension
{
    public static bool IsLateralTo(this Vector2 a, Vector2 b) => a.X == b.X || a.Y == b.Y;

    public static IEnumerable<Vector2> GetRange(this Vector2 from, Vector2 to)
    {
        do {
            yield return from;
            from.X += from.X < to.X ? 1 : from.X > to.X ? -1 : 0;
            from.Y += from.Y < to.Y ? 1 : from.Y > to.Y ? -1 : 0;
        } while (from != to);
        yield return to;
    }
}

/*  Alternative method with Lerp (not as fast for obvious reasons)
public static IEnumerable<Vector2> GetRange(this Vector2 from, Vector2 to)
    {
        var direction = Vector2.Abs(to - from);
        var steps = (int)Math.Max(direction.X, direction.Y);

        for(int i = 0; i <= steps; i++)
        {
            yield return Vector2.Lerp(from, to, i / (float)steps).RoundToInt();
        }
    }

    public static Vector2 RoundToInt(this Vector2 vector)
    {
        vector.X = MathF.Round(vector.X);
        vector.Y = MathF.Round(vector.Y);
        return vector;
    }
}
*/