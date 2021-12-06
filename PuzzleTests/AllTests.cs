using System;
using NUnit.Framework;
using Puzzles;

namespace PuzzleTests;


public class AllTests
{
    // TODO: This is a work in progress to automate tests in the future
    public void BaseTestMethod(Puzzle puzzle, int dayNumber, int? expected1, int? expected2 = null)
    {
        //var data = TestHelpers.ReadFrom(dayNumber);
        puzzle.Init();

        var result1 = puzzle.SolvePart1();
        Assert.AreEqual(result1, expected1);

        if(expected2 != null)
        {
            var result2 = puzzle.SolvePart2();
            Assert.AreEqual(result2, expected2);
        }
    }

}