using System.Collections.Generic;

namespace Puzzles;

public abstract class Puzzle : IInit, ISolver
{
    public abstract void Init(IEnumerable<string> data);
    public abstract int SolvePart1();
    public abstract int SolvePart2();
}

public abstract class Puzzle<T> : Puzzle, IConverter<T>, ISolver<T>
{
    protected T _data;

    public override void Init(IEnumerable<string> data) => _data = Convert(data);
    public override int SolvePart1() => SolvePart1(_data);
    public override int SolvePart2() => SolvePart2(_data);

    public abstract T Convert(IEnumerable<string> data);
    public abstract int SolvePart1(T data);
    public abstract int SolvePart2(T data);
}

public interface IInit
{
    public void Init(IEnumerable<string> data);
}

public interface IConverter<T>
{
    public T Convert(IEnumerable<string> data);
}

public interface ISolver
{
    public int SolvePart1();
    public int SolvePart2();
}

public interface ISolver<T>
{
    public int SolvePart1(T data);
    public int SolvePart2(T data);
}