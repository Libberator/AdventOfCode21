using System;
using System.IO;

namespace AdventOfCode
{
    public class FileReader
    {
        private static readonly string _root = @"C:\AdventOfCode";
        private static readonly string _fileName = "input.txt";

        public static bool ReadFile(string folderName, out string[] data)
        {
            var fullPath = Path.Combine(_root, folderName, _fileName);

            data = Array.Empty<string>();
            if (File.Exists(fullPath))
            {
                data = File.ReadAllLines(fullPath);
                return true;
            }
            return false;
        }
    }
}