using System.Collections.Generic;
using System.Numerics;
using Utilities;

namespace Puzzles;

// The generic T is the return type
public abstract class Puzzle<T> : ISolver<T> where T : INumber<T>
{
    protected readonly string _dataPath;
    public Puzzle(string path) { _dataPath = path; }
    protected virtual IEnumerable<string> LoadFromFile() => FileReader.ReadFrom(_dataPath);
    public abstract T SolvePart1();
    public abstract T SolvePart2();
}

// default int return type
public abstract class Puzzle : Puzzle<int> { protected Puzzle(string path) : base(path) { } }

public interface ISolver<T>
{
    public T SolvePart1();
    public T SolvePart2();
}