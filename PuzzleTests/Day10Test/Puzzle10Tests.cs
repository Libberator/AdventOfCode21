using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle10Tests
{
    private readonly Puzzle<long> _puzzle = new Day10(TestHelpers.TestDataPath(10));
    private readonly long _expectedResult1 = 26397;
    private readonly long _expectedResult2 = 288957;

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