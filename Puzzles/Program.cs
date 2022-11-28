//#define BENCHMARK

using System;
using Utilities;

namespace Puzzles;

public class Program
{
    public static void Main() 
    {
        for (int i = 1; i <= 17; i++)
        {
            var SelectedPuzzle = GetPuzzle(i);
            if (SelectedPuzzle == null) continue;
            Console.WriteLine($"Day {i}.");
#if BENCHMARK
            Benchmark(SelectedPuzzle);
#else
            Console.WriteLine($"Part 1: {SelectedPuzzle.SolvePart1()}");
            Console.WriteLine($"Part 2: {SelectedPuzzle.SolvePart2()}");
#endif
        }

        Console.ReadLine(); // Wait before closing console
    }

    private static void Benchmark(ISolver<int> puzzle)  // change to <int>/<long> as needed
    {
        var iterations = 1000;
        using (new Watch($"Puzzle 1 x {iterations}")) {
            for (int i = 0; i < iterations; i++) {
                puzzle.SolvePart1();
            }
        }

        using (new Watch($"Puzzle 2 x {iterations}")) {
            for (int i = 0; i < iterations; i++) {
                puzzle.SolvePart2();
            }
        }
    }

    private static Puzzle? GetPuzzle(int day) => day switch
    {
        1 => new Day1(FileReader.FullPath(1)),
        2 => new Day2(FileReader.FullPath(2)),
        3 => new Day3(FileReader.FullPath(3)),
        4 => new Day4(FileReader.FullPath(4)),
        5 => new Day5(FileReader.FullPath(5)),
        //6 => new Day6(FileReader.FullPath(6)),
        7 => new Day7(FileReader.FullPath(7)),
        8 => new Day8(FileReader.FullPath(8)),
        9 => new Day9(FileReader.FullPath(9)),
        //10 => new Day10(FileReader.FullPath(10)),
        11 => new Day11(FileReader.FullPath(11)),
        12 => new Day12(FileReader.FullPath(12)),
        //13 => new Day13(FileReader.FullPath(13)),
        //14 => new Day14(FileReader.FullPath(14)),
        15 => new Day15(FileReader.FullPath(15)),
        //16 => new Day16(FileReader.FullPath(16)),
        17 => new Day17(FileReader.FullPath(17)),
        _ => null, // throw new ArgumentOutOfRangeException($"Puzzle for day {day} has not been made yet"),
    };
}