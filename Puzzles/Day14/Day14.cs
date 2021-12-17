using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Puzzles;

public class Day14 : Puzzle<long>
{
    private readonly Dictionary<string, char> _insertionPairs = new();
    private readonly string _template;
    private const string Delimiter = "->";

    public Day14(string path) : base(path)
    {
        bool templateDone = false;
        foreach (var item in LoadFromFile())
        {
            if (!templateDone){
                _template = item;
                templateDone = true;
                continue;
            }
            if(string.IsNullOrWhiteSpace(item)) continue;
            var split = item.Split(Delimiter, StringSplitOptions.TrimEntries);
            _insertionPairs.Add(split[0], split[1].First());
        }
    }

    public override long SolvePart1() => SolveIt(10);  // 2170

    public override long SolvePart2() => SolveIt(40);  // 2422444761283

    private long SolveIt(int cycles){
        Dictionary<string, long> pairCounter1 = new();
        for (int i = 0; i < _template.Length - 1; i++) {
            pairCounter1[_template.Substring(i,2)] = 1;
        }

        for (int i = 1; i <= cycles; i++)
        {
            Dictionary<string, long> pairCounter2 = new();
            foreach (var kvp in pairCounter1)
            {
                var l = $"{kvp.Key[0]}{_insertionPairs[kvp.Key]}";
                var r = $"{_insertionPairs[kvp.Key]}{kvp.Key[1]}";
                pairCounter2.AddToOrCreate(l, kvp.Value);
                pairCounter2.AddToOrCreate(r, kvp.Value);
            }
            pairCounter1 = pairCounter2;

            if (i == cycles){
                Dictionary<char, long> charCounter = new();
                
                foreach (var kvp in pairCounter1) {
                    charCounter.AddToOrCreate(kvp.Key[0], kvp.Value);
                }
                charCounter.AddToOrCreate(_template.Last(), 1);
                
                return AssessDictionary(charCounter);
            }
        }
        return -1;
    }

    private static long AssessDictionary(IDictionary<char, long> dictionary)
    {
        var min = dictionary.MinBy(kvp => kvp.Value).Value;
        var max = dictionary.MaxBy(kvp => kvp.Value).Value;
        return max - min;
    }
}
