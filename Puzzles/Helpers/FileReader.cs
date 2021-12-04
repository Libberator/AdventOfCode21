using System;
using System.Collections.Generic;
using System.IO;

namespace Utilities;

public static class FileReader
{
    private static string FullPath(int number) => $"./Puzzles/Day{number}/input.txt";

    public static bool TryReadFile(int number, out string[] data)
    {
        data = Array.Empty<string>();
        string fullPath = FullPath(number);
        if (File.Exists(fullPath))
        {
            data = File.ReadAllLines(fullPath);
            return true;
        }

        return false;
    }

    public static IEnumerable<string> ReadFrom(int day)
    {
        var path = FullPath(day);
        string? line;
        using var reader = File.OpenText(path);
        while ((line = reader.ReadLine()) != null)
        {
            yield return line;
        }
    }
}