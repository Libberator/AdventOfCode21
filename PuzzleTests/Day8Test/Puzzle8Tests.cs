using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle8Tests
{
    private readonly Puzzle _puzzle = new Day8(TestHelpers.TestDataPath(8));
    private readonly long _expectedResult1 = 0;
    private readonly long _expectedResult2 = 0;

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