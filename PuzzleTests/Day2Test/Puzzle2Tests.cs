using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle2Tests
{
    private readonly Puzzle _puzzle = new Day2(TestHelpers.TestDataPath(2));
    private readonly int _expectedResult1 = 150;
    private readonly int _expectedResult2 = 900;

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