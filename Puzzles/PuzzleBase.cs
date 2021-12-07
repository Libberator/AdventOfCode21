using System.Collections.Generic;
using Utilities;

namespace Puzzles;

public abstract class Puzzle : IInit, ISolver
{
    protected readonly string _dataPath;
    public Puzzle(string path) { _dataPath = path; }
    protected virtual IEnumerable<string> LoadFromFile(string path) => FileReader.ReadFrom(path);
    public abstract void Init();
    public virtual int SolvePart1() => -1;
    public virtual int SolvePart2() => -1;
    public virtual long SolvePart1(bool useLong) => -1;
    public virtual long SolvePart2(bool useLong) => -1;
}

public abstract class Puzzle<T> : Puzzle
{
    protected T _data;
    public Puzzle(string path) : base(path) { }

    public override void Init() => _data = ConvertData(LoadFromFile(_dataPath));
    public override int SolvePart1() => SolvePart1(_data);
    public override int SolvePart2() => SolvePart2(_data);

    protected abstract T ConvertData(IEnumerable<string> data);
    protected abstract int SolvePart1(T data);
    protected abstract int SolvePart2(T data);

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