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
                if(_puzzle.SolvePart1(data, out int part1))
                {
                    Console.WriteLine($"Part 1 Solution: {part1}");
                }
                if(_puzzle.SolvePart2(data, out int part2))
                {
                    Console.WriteLine($"Part 2 Solution: {part2}");
                }
            }
            Console.ReadLine();
        }
    }
}