using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Utilities;

namespace Puzzles;

public class Day13
{
    private readonly List<Point> _data = new();
    private readonly List<(char, int)> _directions = new();
    public Day13(string path)
    {
        bool part1 = true;
        foreach (var item in FileReader.ReadFrom(path)) {
            if (string.IsNullOrWhiteSpace(item)) {
                part1 = false;
                continue;
            }

            if (part1) {
                var items = item.Split(',');
                _data.Add(new Point(int.Parse(items[0]), int.Parse(items[1])));
            }
            else {
                var items = item.Split(' ')[2].Split('=');
                _directions.Add((items[0].First(), int.Parse(items[1])));;
            }
        }
    }

    public int SolvePart1()
    {
        var firstDirection = _directions[0];
        FoldAt(firstDirection.Item1, firstDirection.Item2, _data);
        return _data.Distinct(new Point()).Count();  // 706
    }

    public string SolvePart2()
    {
        foreach (var fold in _directions) {
            FoldAt(fold.Item1, fold.Item2, _data);
        }

        var minX = _data.MinBy(p => p.X).X;
        var maxX = _data.MaxBy(p => p.X).X;
        var minY = _data.MinBy(p => p.Y).Y;
        var maxY = _data.MaxBy(p => p.Y).Y;

        var sb = new StringBuilder();
        for (int row = minY; row <= maxY; row++) {
            sb.Append('\n');
            for (int col = minX; col <= maxX; col++) {
                sb.Append(_data.Any(p => p.X == col && p.Y == row) ? "#" : ".");
            }
        }
        /*
        #....###..####...##.###....##.####.#..#
        #....#..#.#.......#.#..#....#.#....#..#
        #....#..#.###.....#.###.....#.###..####
        #....###..#.......#.#..#....#.#....#..#
        #....#.#..#....#..#.#..#.#..#.#....#..#
        ####.#..#.#.....##..###...##..####.#..#
        */
        return sb.ToString(); // LRFJBJEH
    }

    private static void FoldAt(char letter, int pos, List<Point> data)
    {
        data.ForEach(p =>
        {
            if (letter == 'x') {
                p.RotateAcrossVerticalLine(pos);
            }
            else if (letter == 'y') {
                p.RotateAcrossHorizontalLine(pos);
            }
        });
    }

    private class Point : IEqualityComparer<Point>
    {
        public int X, Y;
        public Point(int x, int y){
            X = x;
            Y = y;
        }
        public Point(){}

        public void RotateAcrossVerticalLine(int xLinePos) {
            if(X > xLinePos) {
                X -= 2 * (X - xLinePos);
            }
        }

        public void RotateAcrossHorizontalLine(int yLinePos) {
            if (Y > yLinePos) {
                Y -= 2 * (Y - yLinePos);
            }
        }

        public bool Equals(Point? a, Point? b)
        {
            return a?.X == b?.X && a?.Y == b?.Y;
        }
        
        public int GetHashCode([DisallowNull] Point obj)
        {
            return (obj.X ^ obj.Y).GetHashCode();
        }
    }
}