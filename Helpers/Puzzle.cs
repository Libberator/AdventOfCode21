using System.Collections.Generic;

namespace AdventOfCode;

public abstract class Puzzle : IInit, ISolver
{
    public abstract void Init(IEnumerable<string> data);
    public abstract int SolvePart1();
    public abstract int SolvePart2();
}

public abstract class Puzzle<T> : Puzzle
{
    protected T _data;
}

public interface ISolver
{
    public int SolvePart1();
    public int SolvePart2();
}

public interface IInit
{
    public void Init(IEnumerable<string> data);
}