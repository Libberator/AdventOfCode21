using System.Collections.Generic;
using Utilities;

namespace Puzzles;

public abstract class Puzzle : ISolver
{
    protected readonly string _dataPath;
    public Puzzle(string path) { _dataPath = path; }
    protected virtual IEnumerable<string> LoadFromFile() => FileReader.ReadFrom(_dataPath);
    public virtual int SolvePart1() => -1;
    public virtual int SolvePart2() => -1;
    public virtual long SolvePart1(bool useLong) => -1;
    public virtual long SolvePart2(bool useLong) => -1;  // created just for Day6
}

public interface ISolver
{
    public int SolvePart1();
    public int SolvePart2();
}