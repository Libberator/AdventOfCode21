using System;

namespace AdventOfCode;

public class Program
{
    public static void Main()
    {
        // select your puzzle here!
        Puzzle selectedPuzzle = new Puzzle2();

        InitializeData(selectedPuzzle);

        SolvePuzzles(selectedPuzzle);

        Console.ReadKey(true); // Wait before closing console
    }

    private static void InitializeData(IInit puzzle)
    {
        puzzle.Init(FileReader.ReadFrom("Day2"));
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