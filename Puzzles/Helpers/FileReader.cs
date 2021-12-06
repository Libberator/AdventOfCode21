using System.Collections.Generic;
using System.IO;

namespace Utilities;

public static class FileReader
{
    public static string FullPath(int number) => $"./Puzzles/Day{number}/input.txt";

    public static string[] GrabAllLines(string path) => File.ReadAllLines(path);

    public static IEnumerable<string> ReadFrom(string path)
    {
        string? line;
        using var reader = File.OpenText(path);
        while ((line = reader.ReadLine()) != null)
        {
            yield return line;
        }
    }
}