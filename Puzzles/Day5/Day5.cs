using System;
using System.Linq;
using System.Collections.Generic;

namespace Puzzles;

// Note: This is currently a placeholder file
// It it filled in with a solution by someone else for Day4
// To compare speed/efficiency of results
public class Day5 : Puzzle
{
    private IReadOnlyList<string> _data;
    private string[] _selectedNumbers;
    private const string X = "X";

    public override void Init(IEnumerable<string> data)
    {
        _data = data.ToList();
        _selectedNumbers = _data[0].Split(',').Select(s => s.ToString()).ToArray();
    }

    public override int SolvePart1()
    {
       var boards = AssembleBoards().ToList();
        for (var i = 0;; i++) {
            var selection = _selectedNumbers[i];
            var result = 0;
            EvaluateBoards(boards, selection, (board) => {
                var sumOfUnmarked = board.Sum(s => s.Where(n => n != X).Select(int.Parse).Sum());
                result = sumOfUnmarked * int.Parse(selection);
            }, true);

            if (result != 0) return result;
        }
    }

    public override int SolvePart2()
    {
        var remainingBoards = AssembleBoards().ToList();
        for (var i = 0;; i++) {
            var selection = _selectedNumbers[i];
            var toCull = new List<string[][]>();
            var result = 0;
            EvaluateBoards(remainingBoards, selection, board => {
                if (remainingBoards.Count == 1) {
                    var sumOfUnmarked = board.Sum(s => s.Where(n => n != X).Select(int.Parse).Sum());
                    result = sumOfUnmarked * int.Parse(selection);
                }

                toCull.Add(board);
            }, false);

            if (result != 0) return result;

            foreach (var cull in toCull) {
                remainingBoards.Remove(cull);
            }
        }
    }

    private void EvaluateBoards(List<string[][]> boards, string selection, Action<string[][]> bingoAction, bool breakOnBingo) {
        foreach (var board in boards) {
            for (var rowIndex = 0; rowIndex < 5; rowIndex++) {
                var row = board[rowIndex];
                for (var colIndex = 0; colIndex < 5; colIndex++) {
                    if (row[colIndex] == selection) {
                        row[colIndex] = X;

                        if (IsBingo(board, rowIndex, colIndex)) {
                            bingoAction(board);
                            if (breakOnBingo) return;
                        }
                    }
                }
            }
        }
    }
    
    private IEnumerable<string[][]> AssembleBoards() {
        var setStrings = _data.Skip(2).ToList();
        var setCount = setStrings.Count(string.IsNullOrEmpty) + 1;

        var skipAmount = 0;
        for (var i = 0; i < setCount; i++) {
            var setRows = setStrings.Skip(skipAmount).Take(5).ToList();
            var set = setRows.Select(r => r.Replace("  "," ").TrimStart(' ').Split(null)).ToArray();

            yield return set;
            skipAmount += 6;
        }
    }

    bool IsBingo(string[][] board, int rowIndex, int colIndex) {
        return board[rowIndex].All(n => n == X) || board.Select(b => b[colIndex]).All(n => n == X);
    }
}