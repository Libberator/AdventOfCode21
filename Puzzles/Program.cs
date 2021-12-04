#define BENCHMARK

using System;
using Utilities;

namespace Puzzles;

public class Program
{
    // Select your puzzle here!
    private static readonly Puzzle SelectedPuzzle = new Day4();
    // The following number is used to find the folder for "input.txt"
    private static readonly int Day = 4;

    public static void Main()
    {
        SelectedPuzzle.Init(FileReader.ReadFrom(Day));

        Console.WriteLine($"Part 1: {SelectedPuzzle.SolvePart1()}");
        Console.WriteLine($"Part 2: {SelectedPuzzle.SolvePart2()}");

#if BENCHMARK
        Benchmark(SelectedPuzzle, requiresInitEveryTime: true);
#endif
        Console.ReadKey(true); // Wait before closing console
    }


    private static void Benchmark(Puzzle puzzle, bool requiresInitEveryTime = false)
    {
        var iterations = 1000;

        if(requiresInitEveryTime){
            using (new Watch($"Puzzle 1 x {iterations}")) 
            {
                for (int i = 0; i < iterations; i++) 
                {
                    puzzle.Init(FileReader.ReadFrom(Day));
                    puzzle.SolvePart1();
                }
            }

            using (new Watch($"Puzzle 2 x {iterations}")) {
                for (int i = 0; i < iterations; i++) {
                    puzzle.Init(FileReader.ReadFrom(Day));
                    puzzle.SolvePart2();
                }
            }
        }

        else
        {
            puzzle.Init(FileReader.ReadFrom(Day));
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
}