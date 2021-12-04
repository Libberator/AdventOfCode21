using System;
using Utilities;

namespace Puzzles;

public class Program
{
    // select your puzzle here!
    private const string Folder = "Day4";  // update input.txt folder location
    private static readonly PuzzleBase SelectedPuzzle = new Puzzle4();

    public static void Main()
    {
        bool benchmark = true;
        if (benchmark){ Benchmark(true);}

        SelectedPuzzle.Init(FileReader.ReadFrom(Folder));

        Console.WriteLine($"Part 1: {SelectedPuzzle.SolvePart1()}");
        Console.WriteLine($"Part 2: {SelectedPuzzle.SolvePart2()}");

        Console.ReadKey(true); // Wait before closing console
    }

    private static void Benchmark(bool requiresInitEveryTime = false)
    {
        var iterations = 1000;

        if(requiresInitEveryTime){
            using (new Watch($"Puzzle 1 x {iterations}")) 
            {
                for (int i = 0; i < iterations; i++) 
                {
                    SelectedPuzzle.Init(FileReader.ReadFrom(Folder));
                    SelectedPuzzle.SolvePart1();
                }
            }

            using (new Watch($"Puzzle 2 x {iterations}")) {
                for (int i = 0; i < iterations; i++) {
                    SelectedPuzzle.Init(FileReader.ReadFrom(Folder));
                    SelectedPuzzle.SolvePart2();
                }
            }
        }

        else
        {
            SelectedPuzzle.Init(FileReader.ReadFrom(Folder));
            using (new Watch($"Puzzle 1 x {iterations}")) 
            {
                for (int i = 0; i < iterations; i++) 
                {
                    SelectedPuzzle.SolvePart1();
                }
            }

            using (new Watch($"Puzzle 2 x {iterations}")) {
                for (int i = 0; i < iterations; i++) {
                    SelectedPuzzle.SolvePart2();
                }
            }
        }

    }
}