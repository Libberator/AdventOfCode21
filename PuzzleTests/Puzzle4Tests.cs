using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle4Tests
{
    private readonly PuzzleBase puzzle = new Puzzle4();
    private int _expectedResult1, _expectedResult2;

    [OneTimeSetUp]
    public void SetUp()
    {
        var data = TestHelpers.ReadFrom(TestHelpers.FullPath(4));

        puzzle.Init(data);

        _expectedResult1 = 4512;
        
        _expectedResult2 = 1924;
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