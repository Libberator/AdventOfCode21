namespace PuzzleTests;

public static class TestHelpers
{
    public static string TestDataPath(int num) 
    { 
        return $"C:/AdventOfCode/PuzzleTests/Day{(num < 10 ? "0" + num : num)}Test/Test{num}.txt";
    }
}