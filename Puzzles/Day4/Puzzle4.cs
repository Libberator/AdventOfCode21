using System;
using System.Collections.Generic;

namespace Puzzles;

public class Puzzle4 : PuzzleBase
{
    private readonly List<Bingo> _allBoards = new();
    public event Action<int> NewNumberCalled = delegate{};
    private int[] _numbersToDraw;
    private int _lastUnmarkedSum, _currentCount = 0;
    private bool _firstSolutionWasFound, _lastSolutionWasFound;

    public override void Init(IEnumerable<string> data)
    {
        var boardData = new List<string>();
        foreach (var line in data)
        {
            if (line.Contains(','))
            {
                _numbersToDraw = Array.ConvertAll(line.Split(','), s => int.Parse(s));
            }
            else if (!string.IsNullOrWhiteSpace(line))
            {
                boardData.Add(line);
            }

            if (boardData.Count == 5)
            {
                _allBoards.Add(new Bingo(this, boardData));
                boardData.Clear();
            }
        }
    }

    public override int SolvePart1()
    {
        while(_currentCount < _numbersToDraw.Length)
        {
            NewNumberCalled?.Invoke(_numbersToDraw[_currentCount]);
            _currentCount++;
            if (_firstSolutionWasFound) break;
        }

        return _lastUnmarkedSum * _numbersToDraw[_currentCount - 1];
    }

    public override int SolvePart2()
    {
        while(_currentCount < _numbersToDraw.Length)
        {
            NewNumberCalled?.Invoke(_numbersToDraw[_currentCount]);
            _currentCount++;
            if (_lastSolutionWasFound) break;
        }

        return _lastUnmarkedSum * _numbersToDraw[_currentCount - 1];
    }

    public void SolutionFound(Bingo source, int solution)
    {
        _lastUnmarkedSum = solution;
        _firstSolutionWasFound = true;

        _allBoards.Remove(source);
        if (_allBoards.Count == 0)
        {
            _lastSolutionWasFound = true;
        }
    }
}

public class Bingo
{
    private readonly Puzzle4 _source;
    public int[,] _numbers = new int[5,5];
    private readonly bool[,] _marked = new bool[5,5];
    private readonly Action<Bingo, int> SolutionFound;

    public Bingo(Puzzle4 source, List<string> newBoard)
    {
        for (int row = 0; row < 5; row++)
        {
            var fiveNums = Array.ConvertAll(newBoard[row].Split(' ', StringSplitOptions.RemoveEmptyEntries), s => int.Parse(s));

            for (int col = 0; col < 5; col++)
            {
                _numbers[row, col] = fiveNums[col];
            }
        }
        source.NewNumberCalled += OnNewNumberCalled;
        SolutionFound = source.SolutionFound;
        _source = source;
    }

    private void OnNewNumberCalled(int number)
    {
        if(HasNumber(number, out int row, out int col))
        {
            if(CheckIfWon(row, col)) ShoutBINGO();
        }
    }

    private void ShoutBINGO()
    {
        var total = GetUnmarkedSums();
        //Console.WriteLine($"We have a Winner! {total}");
        SolutionFound?.Invoke(this, total);
        _source.NewNumberCalled -= OnNewNumberCalled;
    }

    private bool CheckIfWon(int row, int col) => CheckRow(row) || CheckCol(col);

    private bool CheckRow(int row)
    {
        for (int i = 0; i < 5; i++)
        {
            if (_marked[row, i] == true) continue;
            return false;
        }
        return true;
    }

    private bool CheckCol(int col)
    {
        for (int i = 0; i < 5; i++)
        {
            if (_marked[i, col] == true) continue;
            return false;
        }
        return true;
    }

    private int GetUnmarkedSums()
    {
        int sum = 0;
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                if (_marked[row, col] == true) continue;
                sum += _numbers[row, col];
            }
        }
        return sum;
    }

    private bool HasNumber(int number, out int row, out int col)
    {
        row = col = -1;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (_numbers[i, j] != number) continue;

                _marked[i, j] = true;
                row = i;
                col = j;
                return true;
            }
        }
        return false;
    }
}