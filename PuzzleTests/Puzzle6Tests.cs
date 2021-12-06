using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle6Tests
{
    private readonly Puzzle _puzzle = new Day6(TestHelpers.TestDataPath(6));
    private readonly int _expectedResult1 = 5934;
    private readonly long _expectedResult2 = 26984457539;

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
        var result = _puzzle.SolvePart2(true);
        Assert.AreEqual(_expectedResult2, result);
    }
}