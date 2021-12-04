using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle1Tests
{
    private readonly Puzzle puzzle = new Day1();
    private int _expectedResult1, _expectedResult2;

    [OneTimeSetUp]
    public void SetUp()
    {
        var data = TestHelpers.ReadFrom(1);

        puzzle.Init(data);

        _expectedResult1 = 7;
        _expectedResult2 = 5;
    }

    [Test]
    public void SolvePart1Test()
    {
        var result = puzzle.SolvePart1();
        Assert.AreEqual(result, _expectedResult1);
    }

    [Test]
    public void SolvePart2Test()
    {
        var result = puzzle.SolvePart2();
        Assert.AreEqual(result, _expectedResult2);
    }
}