using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections.Concurrent;
using Utilities;

namespace Puzzles;

public class Day5 : Puzzle
{
    private readonly List<(Vector2 , Vector2)> _data = new();
    private const string Arrow = " -> ";
    private const char Delimiter = ',';

    public Day5(string path) : base(path) 
    {
        foreach (string line in LoadFromFile())
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var split = line.Split(Arrow, StringSplitOptions.TrimEntries);
            var from = split[0].Split(Delimiter).Select(int.Parse).ToArray();
            var to = split[1].Split(Delimiter).Select(int.Parse).ToArray();
            _data.Add((new Vector2(from[0], from[1]), new Vector2(to[0], to[1])));
        }
    }

    public override int SolvePart1()
    {
        var spotsHit = new ConcurrentDictionary<Vector2, bool>();
        Parallel.ForEach(_data.Where(pair => pair.Item1.IsLateralTo(pair.Item2)), item =>
        {
            foreach(var point in item.Item1.GetRange(item.Item2)) {
                spotsHit.AddOrUpdate(point, false, (k, v) => v = true );
                //spotsHit[point] = spotsHit.ContainsKey(point); // Not as thread-safe
            }
        });
        return spotsHit.Count(c => c.Value);  // 6710
    }

    public override int SolvePart2()
    {
        var spotsHit = new ConcurrentDictionary<Vector2, bool>();
        Parallel.ForEach(_data, item =>
        {
            foreach(var point in item.Item1.GetRange(item.Item2)) {
                spotsHit.AddOrUpdate(point, false, (k, v) => v = true );
                //spotsHit[point] = spotsHit.ContainsKey(point); // Not as thread-safe
            }
        });
        return spotsHit.Count(c => c.Value); // 20121
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