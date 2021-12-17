using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle14Tests
{
    private readonly Day14 _puzzle = new(TestHelpers.TestDataPath(14));
    private readonly long _expectedResult1 = 1588;
    private readonly long _expectedResult2 = 2188189693529;

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