using System.Collections.Generic;
using System.Linq;

namespace Puzzles;

public class Day12 : Puzzle
{
    private readonly List<(string, string)> _data = new();
    private readonly List<Node> _allNodes = new();

    public Day12(string path) : base(path)
    {
        foreach (var line in LoadFromFile()) {
            var nodePair = line.Split('-');
            _data.Add((nodePair[0], nodePair[1]));
        }

        foreach (var item in _data) // initialize Nodes
        {
            if(!_allNodes.Any(n => n.Name == item.Item1)) {
                _allNodes.Add(new Node(item.Item1));
            }
            if(!_allNodes.Any(n => n.Name == item.Item2)) {
                _allNodes.Add(new Node(item.Item2));
            }
            var node1 = _allNodes.First(n => n.Name == item.Item1);
            var node2 = _allNodes.First(n => n.Name == item.Item2);
            node1.AddConnection(node2);
            node2.AddConnection(node1);
        }
    }

    public override int SolvePart1()
    {
        var result = new List<string>();
        Recurse(_allNodes.First(n => n.Name == "start"), "", result);
        return result.Count;  // 5076
    }

    private void Recurse(Node entryPoint, string currentPath, List<string> allPaths)
    {
        string path = currentPath + $"{entryPoint.Name} ";
        foreach (var next in entryPoint.ConnectedNodes) {
            if (next.Name == "end") {
                allPaths.Add(path + "end");
            }
            else if (next.IsLarge || !currentPath.Contains(next.Name)) {
                Recurse(next, path, allPaths);
            }
        }
    }

    public override int SolvePart2()
    {
        var result = new List<string>();
        Recurse2(_allNodes.First(n => n.Name == "start"), "", result);
        return result.Count;  // 145643
    }

    private void Recurse2(Node entryPoint, string currentPath, List<string> allPaths)
    {
        string path = currentPath + $"{entryPoint.Name} ";
        foreach (var next in entryPoint.ConnectedNodes) {
            if(next.Name == "start") continue;
            if(next.Name == "end") {
                allPaths.Add(path + "end");
            }
            else if (next.IsLarge || !currentPath.Contains(next.Name)) {
                Recurse2(next, path, allPaths); // 1st time thru small nodes
            }
            else if (currentPath.Contains('!')) { 
                continue; // 2nd time through small node already happened
            }
            else {
                Recurse2(next, path + "! ", allPaths); // 2nd time through small node allowed
            }
        }
    }

    public class Node
    {
        public string Name;
        public bool IsLarge;
        public List<Node> ConnectedNodes = new();

        public Node(string name)
        {
            Name = name;
            IsLarge = Name.ToUpper() == Name;
        }

        public void AddConnection(Node toAdd)
        {
            if (!ConnectedNodes.Contains(toAdd))
            {
                ConnectedNodes.Add(toAdd);
            }
        }
    }
}