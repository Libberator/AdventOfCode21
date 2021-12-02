using System;
using Utilities;

namespace Puzzles;

public class Program
{
    private const string Folder = "Day2";  // update input.txt folder location

    public static void Main()
    {
        // select your puzzle here!
        PuzzleBase selectedPuzzle = new Puzzle2();

        InitializeData(selectedPuzzle);
        SolvePuzzles(selectedPuzzle);

        Console.ReadKey(true); // Wait before closing console
    }

    private static void InitializeData(IInit puzzle)
    {
        puzzle.Init(FileReader.ReadFrom(Folder));
    }

    private static void SolvePuzzles(ISolver puzzle)
    {
        try
        {
            int part1 = puzzle.SolvePart1();
            Console.WriteLine($"Part 1 Solution: {part1}");
        }
        catch (NotImplementedException)
        {
            Console.WriteLine("Part 1 not implemented yet.");
        }

        try
        {
            int part2 = puzzle.SolvePart2();
            Console.WriteLine($"Part 2 Solution: {part2}");
        }
        catch (NotImplementedException)
        {
            Console.WriteLine("Part 2 not implemented yet.");
        }
    }
}