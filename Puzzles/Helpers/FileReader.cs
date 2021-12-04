using System;
using System.Collections.Generic;
using System.IO;

namespace Utilities;

public static class FileReader
{
    private static readonly string _root = @"C:\AdventOfCode\Puzzles";
    private static readonly string _fileName = "input.txt";

    private static string FullPath(string folder) => Path.Combine(_root, folder, _fileName);

    public static bool TryReadFile(string folderName, out string[] data)
    {
        data = Array.Empty<string>();
        string fullPath = FullPath(folderName);
        if (File.Exists(fullPath))
        {
            data = File.ReadAllLines(fullPath);
            return true;
        }

        return false;
    }

    public static IEnumerable<string> ReadFrom(string folder)
    {
        var path = FullPath(folder);
        string? line;
        using var reader = File.OpenText(path);
        while ((line = reader.ReadLine()) != null)
        {
            yield return line;
        }
    }
}