using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle5Tests
{
    private readonly Puzzle _puzzle = new Day5(TestHelpers.TestDataPath(5));
    private readonly int _expectedResult1 = 5;
    private readonly int _expectedResult2 = 12;

    [OneTimeSetUp]
    public void SetUp() => _puzzle.Init();

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