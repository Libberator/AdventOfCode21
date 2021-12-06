#define BENCHMARK

using System;
using Utilities;

namespace Puzzles;

public class Program
{
    public static void Main()
    {
        // Adjust your class and path numbers here!
        Puzzle SelectedPuzzle = new Day6(FileReader.FullPath(6));  
        
        SelectedPuzzle.Init();
        Console.WriteLine($"Part 1: {SelectedPuzzle.SolvePart1()}");
        Console.WriteLine($"Part 2: {SelectedPuzzle.SolvePart2(useLong: true)}");

#if BENCHMARK
        Benchmark(SelectedPuzzle, requiresInitEveryTime: false);
#endif
        Console.ReadLine(); // Wait before closing console
    }


    private static void Benchmark(Puzzle puzzle, bool requiresInitEveryTime = false)
    {
        var iterations = 1000;

        if(requiresInitEveryTime){
            using (new Watch($"Puzzle 1 x {iterations}")) 
            {
                for (int i = 0; i < iterations; i++) 
                {
                    puzzle.Init();
                    puzzle.SolvePart1();
                }
            }

            using (new Watch($"Puzzle 2 x {iterations}")) {
                for (int i = 0; i < iterations; i++) {
                    puzzle.Init();
                    puzzle.SolvePart2();
                }
            }
        }

        else
        {
            puzzle.Init();
            using (new Watch($"Puzzle 1 x {iterations}")) {
                for (int i = 0; i < iterations; i++) {
                    puzzle.SolvePart1();
                }
            }

            using (new Watch($"Puzzle 2 x {iterations}")) {
                for (int i = 0; i < iterations; i++) {
                    puzzle.SolvePart2(true);
                }
            }
        }
    }
}