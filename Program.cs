using System;

namespace AdventOfCode;

class Program
{
    public static void Main(string[] args)
    {
        // select your puzzle here!
        PuzzleBase selectedPuzzle = new Puzzle1();

        SolvePuzzle(selectedPuzzle);

        //Console.ReadLine(); // Wait before closing console
    }

    private static void SolvePuzzle(PuzzleBase puzzle)
    {
        string folderName = puzzle.FolderName;
        if(!FileReader.ReadFile(folderName, out string[] data))
        {
            Console.WriteLine("Failed to Import data!");
            return;
        }
        
        if (puzzle.SolvePart1(data, out int part1))
        {
            Console.WriteLine($"{folderName}, Part 1 Solution: {part1}");
        }

        if (puzzle.SolvePart2(data, out int part2))
        {
            Console.WriteLine($"{folderName}, Part 2 Solution: {part2}");
        }
    }
}