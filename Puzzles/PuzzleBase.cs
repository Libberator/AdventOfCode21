using System.Collections.Generic;
using Utilities;

namespace Puzzles;

public abstract class Puzzle : IInit, ISolver
{
    protected readonly string _dataPath;
    public Puzzle(string path) { _dataPath = path; }
    protected virtual IEnumerable<string> LoadFromFile(string path) => FileReader.ReadFrom(path);
    public abstract void Init();
    public abstract int SolvePart1();
    public abstract int SolvePart2();
    public virtual long SolvePart2(bool useLong) => SolvePart2();
}

public abstract class Puzzle<T> : Puzzle, IConverter<T>, ISolver<T>
{
    protected T _data;
    public Puzzle(string path) : base(path) { }

    public override void Init() => _data = ConvertData(LoadFromFile(_dataPath));
    public override int SolvePart1() => SolvePart1(_data);
    public override int SolvePart2() => SolvePart2(_data);

    public abstract T ConvertData(IEnumerable<string> data);
    public abstract int SolvePart1(T data);
    public abstract int SolvePart2(T data);

}

public interface IInit
{
    public void Init();
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

public interface IConverter<T>
{
    public T ConvertData(IEnumerable<string> data);
}