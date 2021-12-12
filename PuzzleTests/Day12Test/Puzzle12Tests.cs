using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle12Tests
{
    private readonly Puzzle _puzzle = new Day12(TestHelpers.TestDataPath(12));
    private readonly int _expectedResult1 = 226;
    private readonly int _expectedResult2 = 3509;

    [Test]
    public void SolvePart1Test()
    {
        var result = _puzzle.SolvePart1();
        Assert.AreEqual(_expectedResult1, result);
    }

    [Test]
    public void SolvePart2Test()
    {
        var result = _puzzle.SolvePart2();
        Assert.AreEqual(_expectedResult2, result);
    }
}