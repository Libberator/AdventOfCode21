using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles;

public class Day8 : Puzzle
{
    private readonly List<(string, string)> _data = new();
    public static readonly int[] UniqueNumbers = new int[4] { 2, 3, 4, 7 };

    public Day8(string path) : base(path)
    {
        foreach(var line in LoadFromFile()) {
            if(string.IsNullOrWhiteSpace(line)) continue;
            var split = line.Split('|', StringSplitOptions.TrimEntries);
            _data.Add((split[0], split[1]));
        }
    }

    public override int SolvePart1()
    {
        int sum = 0;
        foreach (var pair in _data) {
            var furtherSplit = pair.Item2.Split(' ');
            foreach(var number in furtherSplit) {
                if (UniqueNumbers.Contains(number.Length)) {
                    sum++;
                }
            }
        }
        return sum;
    }

    public override int SolvePart2()
    {
        int sum = 0;
        foreach(var line in _data) {
            Dictionary<int, string> mappings = new();
            var clues = line.Item1.SplitAndSortByLength();
            mappings[1] = clues[0];
            mappings[7] = clues[1];
            mappings[4] = clues[2];
            mappings[8] = clues[9];

            // signals of length five: 2, 3, 5
            for(int i = 3; i < 6; i++) {
                if(clues[i].Minus(mappings[7]).Length == 2) {
                    mappings[3] = clues[i];
                }
                else if(clues[i].Minus(mappings[4]).Length == 2) {
                    mappings[5] = clues[i];
                }
                else {
                    mappings[2] = clues[i];
                }
            }

            // signals of length six: 0, 6, 9
            for(int i = 6; i < 9; i++) {
                if(mappings[8].Minus(mappings[1]).Minus(clues[i]).Length == 0) {
                    mappings[6] = clues[i];
                }
                else if(clues[i].Minus(mappings[3]).Length == 1) {
                    mappings[9] = clues[i];
                }
                else {
                    mappings[0] = clues[i];
                }
            }

            var fourNumbers = line.Item2.Split(' ');
            int[] values = new int[4];
            for(int i = 0; i < 4; i++) {
                values[i] = DecodeSignal(fourNumbers[i], mappings);
            }
            sum += ConcatNumbers(values);
        }
        return sum;
    }

    public static int DecodeSignal(string signal, Dictionary<int, string> mapping){
        foreach(var keyValuePair in mapping){
            if (keyValuePair.Value.All(c => signal.Contains(c))){
                if(signal.All(c => keyValuePair.Value.Contains(c))){
                    return keyValuePair.Key;
                }
            }
        }
        Console.WriteLine("Something went horribly wrong.");
        return -1;
    }

    private static int ConcatNumbers(int[] d) {
        return d[0] * 1000 + d[1] * 100 + d[2] * 10 + d[3];
    }
}

public static class StringExtensions
{
    public static string[] SplitAndSortByLength(this string input) {
        return input.Split(' ').OrderBy(s => s.Length).ToArray();
    }

    public static string Minus(this string orig, string remove) {
        return new string(orig.Where(c => !remove.Contains(c)).ToArray());
    }
}

