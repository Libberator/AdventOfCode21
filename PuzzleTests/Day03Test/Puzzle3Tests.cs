using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle3Tests
{

    private readonly Puzzle _puzzle = new Day3(TestHelpers.TestDataPath(3));
    private readonly int _expectedResult1 = 198;
    private readonly int _expectedResult2 = 230;

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