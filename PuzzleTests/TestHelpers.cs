using System;
using System.IO;

namespace PuzzleTests;

public static class TestHelpers
{
    public static string TestDataPath(int num)
    {
        var folder = $"Day{num:D2}Test";
        var file = $"Test{num}.txt";
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folder, file);
    }
}