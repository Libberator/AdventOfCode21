namespace AdventOfCode;

public abstract class PuzzleBase
{
    public abstract string FolderName { get; }
    public virtual bool SolvePart1(string[] data, out int solution)
    {
        solution = -1;
        return false;
    }

    public virtual bool SolvePart2(string[] data, out int solution)
    {
        solution = -1;
        return false;
    }
}