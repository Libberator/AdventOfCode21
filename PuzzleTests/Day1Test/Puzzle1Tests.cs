using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle1Tests
{
    private Puzzle _puzzle;
    private readonly int _expectedResult1 = 7;
    private readonly int  _expectedResult2 = 5;

    [OneTimeSetUp]
    public void SetUp() => _puzzle =new Day1(TestHelpers.TestDataPath(1));

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