using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles;

public class Day9 : Puzzle
{
    private readonly string[] _data;
    private readonly int _rows, _cols;
    private bool IsWithinBounds(int row, int col) => row >= 0 && row < _rows && col >= 0 && col < _cols;

    public Day9(string path) : base(path)
    {
        _data = LoadFromFile().ToArray();
        _rows = _data.Length;
        _cols = _data[0].Length;
    }

    public override int SolvePart1()
    {
        int sum = 0;
        for(int i = 0; i < _rows; i++)
        {
            for(int j = 0; j < _cols; j++)
            {
                if(IsALowPoint(i, j, _data[i][j]))
                {
                    sum += 1 + (int)char.GetNumericValue(_data[i][j]);
                }
            }
        }
        return sum;
    }

    public override int SolvePart2()
    {
        bool[,] traversedPoints = new bool[_rows,_cols];
        List<int> basinSizes = new(); // TODO: implement better way to store top3 to save on memory
        for(int i = 0; i < _rows; i++)
        {
            for(int j = 0; j < _cols; j++)
            {
                if(traversedPoints[i,j] || _data[i][j] == '9') continue;

                int basinSize = Recurse(i, j, 0, traversedPoints);
                basinSizes.Add(basinSize);
            }
        }
        var topThree = basinSizes.OrderByDescending(v => v).Take(3).ToArray();
        return topThree[0] * topThree[1] * topThree[2];
    }

    private bool IsALowPoint(int row, int col, char num){
        if(col < _cols - 1) { // check right
            if(_data[row][col + 1] <= num) return false;
        }
        if(col > 0) { // left
            if(_data[row][col - 1] <= num) return false;
        }
        if(row < _rows - 1) { // down
            if(_data[row + 1][col] <= num) return false;
        }
        if(row > 0) { // up
            if(_data[row - 1][col] <= num) return false;
        }
        return true;
    }

    private int Recurse(int row, int col, int sum, bool[,] traversed)
    {
        if(!IsWithinBounds(row, col)) return 0;
        if(traversed[row, col] || _data[row][col] == '9') return 0;

        traversed[row, col] = true;

        return 1 + 
            Recurse(row, col + 1, sum, traversed) + // right
            Recurse(row, col - 1, sum, traversed) + // left
            Recurse(row + 1, col, sum, traversed) + // down
            Recurse(row - 1, col, sum, traversed); // up
    }
}