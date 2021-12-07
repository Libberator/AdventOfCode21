using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle7Tests
{
    private Puzzle _puzzle;
    private readonly long _expectedResult1 = 37;
    private readonly long _expectedResult2 = 168;

    [OneTimeSetUp]
    public void SetUp() => _puzzle= new Day7(TestHelpers.TestDataPath(7));

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