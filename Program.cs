using System;
namespace AdventOfCode
{
    class Program
    {
        private static Puzzle _puzzle = new Day1();  // select your puzzle here

        static void Main(string[] args)
        {
            // automatically get Folder name from matching Class name
            string folderName = _puzzle.GetType().Name;
            
            string[] data = FileReader.ReadFile(folderName);
            
            if (data == null)
            {
                Console.WriteLine("Failed to Import data!");
            }
            else
            {
                var solution = _puzzle.Solve(data);
                Console.WriteLine(solution);
            }

            Console.ReadLine();
        }
    }
}