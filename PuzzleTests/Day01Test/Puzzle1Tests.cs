using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle1Tests
{
    private readonly Puzzle _puzzle = new Day1(TestHelpers.TestDataPath(1));
    private readonly int _expectedResult1 = 7;
    private readonly int  _expectedResult2 = 5;

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