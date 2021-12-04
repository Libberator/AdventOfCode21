using System;
using System.Collections.Generic;

namespace Puzzles;

public class Day4 : Puzzle
{
    private readonly List<Bingo> _allBoards = new();
    public event Action<int> NewNumberCalled = delegate{};
    private int[] _numbersToDraw;
    private int _totalBoardsRemaining, _lastUnmarkedSum, _lastNumberCalled;
    private bool _firstBingoWasCalled, _lastBingoWasCalled;

    public override void Init(IEnumerable<string> data)
    {
        _allBoards.Clear();
        var boardData = new List<int[]>();
        foreach (var line in data)
        {
            if (line.Contains(','))
            {
                _numbersToDraw = Array.ConvertAll(line.Split(','), s => int.Parse(s));
            }
            else if (!string.IsNullOrWhiteSpace(line))
            {
                var fiveNums = Array.ConvertAll(line.Split(' ', StringSplitOptions.RemoveEmptyEntries), s => int.Parse(s));
                boardData.Add(fiveNums);
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
        ResetBoards();
        
        foreach (int number in _numbersToDraw)
        {
            NewNumberCalled?.Invoke(number);
            _lastNumberCalled = number;
            if (_firstBingoWasCalled) break;
        }

        return _lastUnmarkedSum * _lastNumberCalled;
    }

    public override int SolvePart2()
    {
        ResetBoards();

        foreach (int number in _numbersToDraw)
        {
            NewNumberCalled?.Invoke(number);
            _lastNumberCalled = number;
            if (_lastBingoWasCalled) break;
        }

        return _lastUnmarkedSum * _lastNumberCalled;
    }

    public void SolutionFound(int solution)
    {
        _lastUnmarkedSum = solution;
        _firstBingoWasCalled = true;
        _totalBoardsRemaining--;
        
        if (_totalBoardsRemaining == 0)
        {
            _lastBingoWasCalled = true;
        }
    }

    private void ResetBoards()
    {
        _firstBingoWasCalled = _lastBingoWasCalled = false;
        _totalBoardsRemaining = _allBoards.Count;
        NewNumberCalled = delegate {};  // clear all event subscribers
        foreach (var board in _allBoards)
        {
            board.ResetBoard();
        }
    }
}

public class Bingo
{
    public int[,] Board = new int[5,5];
    private bool[,] _marked = new bool[5,5];
    private readonly Day4 _numberShouter;
    private readonly Action<int> ShoutBingo;

    public Bingo(Day4 source, List<int[]> newBoard)
    {
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                Board[row, col] = newBoard[col][row];
            }
        }
        _numberShouter = source;
        ShoutBingo = source.SolutionFound;
    }

    public void ResetBoard()
    {
        _marked = new bool[5,5];
        ListenForNumbers();
    }

    private void ListenForNumbers() => _numberShouter.NewNumberCalled += OnNewNumberCalled;
    private void StopListeningForNumbers() => _numberShouter.NewNumberCalled -= OnNewNumberCalled;

    private void OnNewNumberCalled(int number)
    {
        if(HasNumber(number, out int row, out int col)) 
        {
            if(CheckForBingo(row, col))
            {
                ShoutBingo?.Invoke(GetUnmarkedSums());
                StopListeningForNumbers();
            }
        }
    }

    private bool CheckForBingo(int row, int col) => CheckRow(row) || CheckCol(col);

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
                sum += Board[row, col];
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
                if (Board[i, j] != number) continue;

                _marked[i, j] = true;
                row = i;
                col = j;
                return true;
            }
        }
        return false;
    }
}