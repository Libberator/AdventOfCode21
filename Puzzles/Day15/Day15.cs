using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puzzles;

public class Day15 : Puzzle
{
    private readonly string[] _data;
    
    // TODO: potentially use 2D array instead of List
    private readonly List<Node> _nodes = new();

    public Day15(string path) : base(path) => _data = LoadFromFile().ToArray();

    private void CreateNodes()
    {
        object lockObject = new();
        Parallel.For(0, _data.Length, row => {
            var line = _data[row];
            Parallel.For(0, line.Length, col =>{
                lock (lockObject){
                    _nodes.Add(new Node(col, row, line.ElementAt(col) - '0'));
                }
            });
        });
    }

    private void InitializeNodes() {
        Parallel.ForEach(_nodes, n => {
            n.AssignNeighbors(_nodes);
        });
    }

    private void ExtendNodeGrid()
    {
        var originalNodes = _nodes.ToArray();
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                if (col == 0 && row == 0) continue;
                var xIncrement = _data[0].Length * col;
                var yIncrement = _data.Length * row;
                var valIncrement = col + row;
                _nodes.AddRange(originalNodes.Select(n => n = new Node
                    (n.X + xIncrement, n.Y + yIncrement, Increment(n.Value, valIncrement))));
            }
        }

        static int Increment(int orig, int toAdd) => orig + toAdd > 9 ? orig + toAdd - 9 : orig + toAdd;
    }


    public override int SolvePart1()
    {
        CreateNodes();
        InitializeNodes();

        var path = FindPath(_nodes.First(n => n.X == 0 && n.Y == 0), _nodes.MaxBy(n => n.X + n.Y)); 
        return path.Sum(n => n.Value);  // 714
    }

    public override int SolvePart2()
    {
        ExtendNodeGrid();
        InitializeNodes();

        var path = FindPath(_nodes.First(n => n.X == 0 && n.Y == 0), _nodes.MaxBy(n => n.X + n.Y));
        return path.Sum(n => n.Value);  // 2948
    }

    public static List<Node> FindPath(Node start, Node end)
    {
        var toSearch = new List<Node>() { start };
        var processed = new List<Node>();

        while (toSearch.Any()) {
            var current = toSearch[0];
            foreach (var t in toSearch) {
                if (t.F < current.F || t.F == current.F && t.H < current.H){
                    current = t;
                }
            } 

            processed.Add(current);
            toSearch.Remove(current);

            if(current == end) {
                var currentNode = end;
                var path = new List<Node>();
                while (currentNode != start){
                    path.Add(currentNode);
                    currentNode = currentNode.Connection;
                }
                return path;
            }

            foreach (var neighbor in current.Neighbors.Where(n => !processed.Contains(n))) {
                var inSearch = toSearch.Contains(neighbor);
                var costToNeighbor = current.G + neighbor.Value;

                if(!inSearch || costToNeighbor < neighbor.G){
                    neighbor.SetG(costToNeighbor);
                    neighbor.SetConnection(current);
                
                    if(!inSearch){
                        neighbor.SetH(neighbor.GetDistance(end));
                        toSearch.Add(neighbor);
                    }
                }
            }
        }
        return null;
    }

    public class Node
    {
        public Node Connection { get; private set; }
        public List<Node> Neighbors { get; private set; }
        public int Value { get; private set; }  // cost to go to this node
        public int X, Y;
        public int G { get; private set; } // G = total cost from start (all prev Values + this Value),
        public int H { get; private set; } // Distance to target node - helps travel diagonally
        public int F => G + H;

        public Node(int x, int y,  int value)
        {
            Value = value;
            X = x;
            Y = y;
        }

        public void SetG(int val) => G = val;
        public void SetH(int val) => H = val;
        public int GetDistance(Node target) => target.X - X + target.Y - Y;
        public void SetConnection(Node node) => Connection = node;
        public void AssignNeighbors(List<Node> allNodes)
        {
            Neighbors = new();
            Neighbors.AddRange(allNodes.Where(n => (n.Y == Y && Math.Abs(n.X - X) == 1) ||
                                                   (n.X == X && Math.Abs(n.Y - Y) == 1)));
        }
    }
}