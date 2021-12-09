using System;
using System.Linq;

namespace Puzzles;

public class Day9 : Puzzle
{
    private readonly string[] _data;
    private readonly int _rows, _cols;

    public Day9(string path) : base(path)
    {
        _data = LoadFromFile().ToArray();
        _rows = _data.Length;
        _cols = _data[0].Length;
    }

    public override int SolvePart1()
    {
        int sum = 0;
        for(int i = 0; i < _rows; i++){
            for(int j = 0; j < _cols; j++){
                if(IsALowPoint(i, j, _data[i][j])){
                    sum += 1 + (int)char.GetNumericValue(_data[i][j]);
                }
            }
        }
        return sum;
    }

    public override int SolvePart2()
    {

        // keep track of the three largest basins


        // multiply the 3 basin sizes together
        return -1;
    }

    public bool IsALowPoint(int row, int col, char num){
        if(col < _cols - 1){ // check right
            if(_data[row][col + 1] <= num) return false;
        }
        if(col > 0){ // left
            if(_data[row][col - 1] <= num) return false;
        }
        if(row < _rows - 1){ // down
            if(_data[row + 1][col] <= num) return false;
        }
        if(row > 0){ // up
            if(_data[row - 1][col] <= num) return false;
        }
        return true;
    }




}