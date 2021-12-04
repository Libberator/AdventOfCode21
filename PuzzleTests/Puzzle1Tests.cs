using System;
using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle1Tests
{
    private Puzzle1 _p1;
    private int[] _expectedTestData;
    private string[] _testData;
    private int _expectedResult1, _expectedResult2;

    [OneTimeSetUp]
    public void SetUp()
    {
        _p1 = new Puzzle1();
        _testData = new string[] 
        { 
            "199", "200", "208", "210", "200", "207", "240", "269", "260", "263"
        };
        _expectedTestData = new int[] 
        { 
            199, 200, 208, 210, 200, 207, 240, 269, 260, 263
        };
        _expectedResult1 = 7;
        _expectedResult2 = 5;
    }

    [Test]
    public void ConvertTest()
    {
        var result = _p1.Convert(_testData);
        Assert.AreEqual(result, _expectedTestData);
    }

    [Test]
    public void SolvePart1Test()
    {
        var result = _p1.SolvePart1(_expectedTestData);
        Assert.AreEqual(result, _expectedResult1);
    }

    [Test]
    public void SolvePart2Test()
    {
        var result = _p1.SolvePart2(_expectedTestData);
        Assert.AreEqual(result, _expectedResult2);
    }
}