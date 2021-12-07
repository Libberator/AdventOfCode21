using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle6Tests
{
    private readonly Puzzle<long> _puzzle = new Day6(TestHelpers.TestDataPath(6));  // custom return type for Day6
    private readonly long _expectedResult1 = 5934;
    private readonly long _expectedResult2 = 26984457539;

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