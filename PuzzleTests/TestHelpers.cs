using System.IO;
using System.Collections.Generic;

namespace PuzzleTests;

public static class TestHelpers
{
    public static string TestDataPath(int num) 
    { 
        return $"C:/AdventOfCode/PuzzleTests/TestFiles/Test{num}.txt";
    }
}