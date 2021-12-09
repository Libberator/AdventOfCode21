//#define BENCHMARK

using System;
using Utilities;

namespace Puzzles;

public class Program
{
    public static void Main()
    {
        // Adjust your class and path numbers here!
        Puzzle SelectedPuzzle = new Day9(FileReader.FullPath(9));  
        
        Console.WriteLine($"Part 1: {SelectedPuzzle.SolvePart1()}");
        Console.WriteLine($"Part 2: {SelectedPuzzle.SolvePart2()}");

#if BENCHMARK
        Benchmark(SelectedPuzzle);
#endif
        Console.ReadLine(); // Wait before closing console
    }

    private static void Benchmark(Puzzle puzzle)
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
}