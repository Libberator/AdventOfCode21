//#define BENCHMARK

using System;
using Utilities;

namespace Puzzles;

public class Program
{
    public static void Main() {
        // Adjust your class and path numbers here!
        var SelectedPuzzle = new Day16(FileReader.FullPath(16));  
        
        Console.WriteLine($"Part 1: {SelectedPuzzle.SolvePart1()}");
        Console.WriteLine($"Part 2: {SelectedPuzzle.SolvePart2()}");

#if BENCHMARK
        Benchmark(SelectedPuzzle);
#endif
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
}