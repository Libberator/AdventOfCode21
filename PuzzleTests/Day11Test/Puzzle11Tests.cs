using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle11Tests
{
    private readonly Puzzle _puzzle = new Day11(TestHelpers.TestDataPath(11));
    private readonly int _expectedResult1 = 1656;
    private readonly int _expectedResult2 = 195;

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