using System.Collections.Generic;
using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle2Tests
{
    private Puzzle2 _p2;
    private string[] _testData;
    private List<(string, int)> _expectedTestData;
    private int _expectedResult1, _expectedResult2;

    [OneTimeSetUp]
    public void SetUp()
    {
        _p2 = new Puzzle2();
        _testData = new string[] 
        { 
            "forward 5",
            "down 5",
            "forward 8",
            "up 3",
            "down 8",
            "forward 2"
        };
        _expectedTestData = new List<(string, int)>()
        { 
            ("forward", 5),
            ("down", 5),
            ("forward", 8),
            ("up", 3),
            ("down", 8),
            ("forward", 2)
        };
        _expectedResult1 = 150;
        _expectedResult2 = 900;
    }

    [Test]
    public void ConvertTest()
    {
        var result = _p2.Convert(_testData);
        Assert.AreEqual(result, _expectedTestData);
    }

    [Test]
    public void SolvePart1Test()
    {
        var result = _p2.SolvePart1(_expectedTestData);
        Assert.AreEqual(result, _expectedResult1);
    }

    [Test]
    public void SolvePart2Test()
    {
        var result = _p2.SolvePart2(_expectedTestData);
        Assert.AreEqual(result, _expectedResult2);
    }
}