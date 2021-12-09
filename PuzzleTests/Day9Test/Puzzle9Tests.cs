using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle9Tests
{
    private readonly Puzzle _puzzle = new Day9(TestHelpers.TestDataPath(9));
    private readonly long _expectedResult1 = 15;
    private readonly long _expectedResult2 = 1134;

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