using System;
using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;

[TestFixture]
public class Puzzle3Tests
{
    private Puzzle3 _p3;
    private string[] _testData;

    private int _expectedResult1, _expectedResult2;

    [OneTimeSetUp]
    public void SetUp()
    {
        var data = TestHelpers.ReadFrom(TestHelpers.FullPath(3));

        _p3 = new Puzzle3();
        _p3.Init(data);

        _expectedResult1 = 198;
        
        _expectedResult2 = 230;
    }

    [Test]
    public void SolvePart1Test()
    {
        var result = _p3.SolvePart1();
        Assert.AreEqual(result, _expectedResult1);
    }

    [Test]
    public void SolvePart2Test()
    {
        var result = _p3.SolvePart2();
        Assert.AreEqual(result, _expectedResult2);
    }

}