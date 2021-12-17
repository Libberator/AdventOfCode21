using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Utilities;

namespace Puzzles;

public class Day17 : Puzzle
{
    private readonly Bounds _bounds;

    public Day17(string path) : base(path)
    {
        var splitLine = LoadFromFile().First().Split(' ');
        var xValues = splitLine[2].Split('=')[1].Split("..");
        var yValues = splitLine[3].Split('=')[1].Split("..");
        _bounds = new Bounds(int.Parse(xValues[0]), int.Parse(xValues[1].Minus(",")), int.Parse(yValues[0]), int.Parse(yValues[1]));
    }

    public override int SolvePart1()
    {
        var minXVelocity = GetMinimumXVelocity(_bounds.XMin);
        return TestTrajectories(minXVelocity);  // 5778
    }

    public override int SolvePart2()
    {
        var minXVelocity = GetMinimumXVelocity(_bounds.XMin);
        return TestTrajectories(minXVelocity, part2:true);  // 2576
    }

    private int TestTrajectories(int minXVelocity, bool part2 = false)
    {
        int successes = 0;
        for (int x = minXVelocity; x < _bounds.XMax + 1; x++)
        {
            for (int y = 150; y > _bounds.YMin - 1; y--)
            {
                if (TestTrajectory(new Vector2(x, y)))
                {
                    successes++;
                    if (!part2) return Utils.GetPascals(y);
                }
            }
        }
        return successes;
    }

    private bool TestTrajectory(Vector2 velocity)
    {
        (int x, int y) vel = ((int)velocity.X, (int)velocity.Y);
        Vector2 newVelocity = new(velocity.X, velocity.Y);
        Vector2 position = new(0,0);
        int step = 0;
        while(!_bounds.HasOvershot(position)){
            step++;
            position += newVelocity;
            ApplyPhysics(ref newVelocity);
            if(_bounds.IsWithinBounds((int)position.X, (int)position.Y)){
                //Console.WriteLine($"Velocity of {vel.x}, {vel.y} passed in {step} steps");
                return true;
            }
        }
        return false;
    }

    private static int GetMinimumXVelocity(int lowerXBound, int startingGuess = 5)
    {
        while (Utils.GetPascals(startingGuess) < lowerXBound){
            startingGuess++;
        }
        return startingGuess;
    }

    private static void ApplyPhysics(ref Vector2 vel)
    {
        ApplyDrag(ref vel);
        ApplyGravity(ref vel);
    }

    private static void ApplyDrag(ref Vector2 vel){
        vel.X += vel.X > 0 ? -1 : vel.X < 0 ? 1 : 0;
    }
    private static void ApplyGravity(ref Vector2 vel){
        vel.Y--;
    }
}

public class Bounds
{
    public readonly int XMin, XMax, YMin, YMax;

    public Bounds(int xMin, int xMax, int yMin, int yMax)
    {
        XMin = xMin;
        XMax = xMax;
        YMin = yMin;
        YMax = yMax;
    }

    public bool IsWithinBounds(Vector2 pos) => IsWithinBounds((int)pos.X, (int)pos.Y);
    public bool IsWithinBounds(int x, int y) => IsInHorizontalBounds(x) && IsInVerticalBounds(y);
    public bool IsInHorizontalBounds(int x) => x >= XMin && x <= XMax;
    public bool IsInVerticalBounds(int y) => y >= YMin && y <= YMax;
    public bool HasOvershot(Vector2 pos) => pos.X > XMax || pos.Y < YMin;
}