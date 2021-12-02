using System.Collections.Generic;
using NUnit.Framework;
using Puzzles;

namespace AdventTests;

[TestFixture]
public class Day2Tests
{
    private Puzzle2 _p2;
    private string[] _testData;
    private List<(string, int)> _expectedTestData;
    private int _expectedResult1, _expectedResult2;

    [SetUp]
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
    public void TestPuzzle2_Convert()
    {
        var result = _p2.Convert(_testData);
        Assert.AreEqual(result, _expectedTestData);
    }

    [Test]
    public void TestPuzzle2_1()
    {
        var result = _p2.SolvePart1(_expectedTestData);
        Assert.AreEqual(result, _expectedResult1);
    }

    [Test]
    public void TestPuzzle2_2()
    {
        var result = _p2.SolvePart2(_expectedTestData);
        Assert.AreEqual(result, _expectedResult2);
    }
}