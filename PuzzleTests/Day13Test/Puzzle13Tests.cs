using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle13Tests
{
    private readonly Day13 _puzzle = new(TestHelpers.TestDataPath(13));
    private readonly int _expectedResult1 = 17;
    private readonly string _expectedResult2 = "\n#####\n#...#\n#...#\n#...#\n#####";

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