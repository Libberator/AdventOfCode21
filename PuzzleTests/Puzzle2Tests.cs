using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle2Tests
{
    private readonly PuzzleBase puzzle = new Puzzle2();
    private int _expectedResult1, _expectedResult2;

    [OneTimeSetUp]
    public void SetUp()
    {
        var data = TestHelpers.ReadFrom(TestHelpers.FullPath(2));

        puzzle.Init(data);

        _expectedResult1 = 150;
        _expectedResult2 = 900;
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