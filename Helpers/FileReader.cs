using System;
using System.IO;

namespace AdventOfCode
{
    public class FileReader
    {
        private static string _root = @"C:\AdventOfCode";
        private static string _fileName = "input.txt";

        public static string[] ReadFile(string folderName)
        {
            var fullPath = Path.Combine(_root, folderName, _fileName);

            if (!File.Exists(fullPath)) { return null; }
            
            return File.ReadAllLines(fullPath);
        }
     
    }
}