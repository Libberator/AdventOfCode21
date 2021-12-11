using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles;

public class Day10 : Puzzle<long>
{
    private readonly string[] _data;
    private readonly char[] OpeningBraces = new char[4] { '(', '[', '{', '<' };
    private readonly Dictionary<char, (char, int)> PairPointMappings = new() {
        [')'] = ('(' ,3),
        [']'] = ('[', 57),
        ['}'] = ('{', 1197),
        ['>'] = ('<', 25137)
    };
    private readonly Dictionary<char,  long> AutoCompleteMappings = new() {
        ['('] = 1,
        ['['] = 2,
        ['{'] = 3,
        ['<'] = 4
    };

    public Day10(string path) : base(path) => _data = LoadFromFile().ToArray();

    public override long SolvePart1()
    {
        long sum = 0;
        Stack<char> lastOpeningBrace = new();
        foreach (var line in _data)
        {
            lastOpeningBrace.Clear();
            foreach (char brace in line)
            {
                if (OpeningBraces.Contains(brace))
                {
                    lastOpeningBrace.Push(brace);
                }
                else if(lastOpeningBrace.Peek() == PairPointMappings[brace].Item1)
                {
                    lastOpeningBrace.Pop();
                }
                else
                {
                    sum += PairPointMappings[brace].Item2;
                    break;
                }
            }
        }
        return sum; // 341823
    }

    public override long SolvePart2()
    {
        Stack<char> lastOpeningBrace = new();
        List<long> scores = new();
        foreach (var line in _data)
        {
            bool errorFound = false;
            lastOpeningBrace.Clear();
            foreach (char brace in line)
            {
                if (OpeningBraces.Contains(brace))
                {
                    lastOpeningBrace.Push(brace);
                }
                else if(lastOpeningBrace.Peek() == PairPointMappings[brace].Item1)
                {
                    lastOpeningBrace.Pop();
                }
                else
                {
                    errorFound = true;
                    break;
                }
            }
            if(errorFound) continue;
            long score = 0;
            int length = lastOpeningBrace.Count;
            for (int i = 0; i < length; i++)
            {
                score *= 5;
                score += AutoCompleteMappings[lastOpeningBrace.Pop()];
            }
            scores.Add(score);
        }
        return scores.OrderBy(v => v).ElementAt(scores.Count / 2); // 2801302861
    }
}