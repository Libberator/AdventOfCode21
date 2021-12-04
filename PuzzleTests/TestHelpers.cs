using System.IO;
using System.Collections.Generic;

namespace PuzzleTests;

public static class TestHelpers
{
    public static string FullPath(int num) 
    { 
        return $"C:/AdventOfCode/PuzzleTests/TestFiles/Test{num}.txt";
    }

    public static IEnumerable<string> ReadFrom(int day)
    {
        string path = FullPath(day);

        string? line;
        using var reader = File.OpenText(path);
        while ((line = reader.ReadLine()) != null) yield return line;
    }
}