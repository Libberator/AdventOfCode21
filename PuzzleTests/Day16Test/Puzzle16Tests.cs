using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle16Tests
{
    private readonly Day16 _puzzle = new(TestHelpers.TestDataPath(16));
    private readonly long _expectedResult1 = 16;
    //private readonly long _expectedResult2 = 54;

    [Test]
    public void SolvePart1Test()
    {
        var result = _puzzle.SolvePart1();
        Assert.AreEqual(_expectedResult1, result);
    }

    /*[Test]
    public void SolvePart2Test()
    {
        var result = _puzzle.SolvePart2();
        Assert.AreEqual(_expectedResult2, result);
    }*/
}