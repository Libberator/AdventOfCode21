using System;
using System.Linq;

namespace Puzzles;

public class Day18 : Puzzle
{
    private readonly string[] _data;

    public Day18(string path) : base(path) => _data = LoadFromFile().ToArray();

    public override int SolvePart1()
    {
        //create binary trees,
        

        return -1;
    }

    public override int SolvePart2()
    {
        return -1;
    }

}


public class Branch
{
    public Branch? Parent;
    public Branch? LeftChild, RightChild;
    public int Value { get; private set; } = 0;

    public Branch(int leftVal, int rightVal, Branch? parent = null){
        Parent = parent;
        LeftChild = new Branch(leftVal, this);
        RightChild = new Branch(rightVal, this);
    }

    public Branch(int value, Branch? parent = null)
    {
        Parent = parent;
        Value = value;
    }

    public Branch() {}
    

    public bool HasChild => LeftChild != null || RightChild != null;
    public bool IsRoot => Parent == null;

    public static Branch Add(Branch currentRoot, Branch newBranch)
    {
        Branch newRoot = new();
        newRoot.LeftChild = currentRoot;
        currentRoot.Parent = newRoot;
        newBranch.RightChild = newBranch;
        newBranch.Parent = newRoot;
        return newRoot;
    }

    public void Split(){
        int leftVal = Value / 2;
        int rightVal = Value % 2 == 1 ? Value / 2 + 1 : Value / 2;
        LeftChild = new Branch(leftVal, this);
        RightChild = new Branch(rightVal, this);
    }

    public void ExplodeChildren()
    {
        if(!HasChild) {
            return;
        }
        LeftChild!.ExplodeChildren();
        RightChild!.ExplodeChildren();

        SendValueLeft(LeftChild!.Value);
        SendValueRight(RightChild!.Value);

        LeftChild = null;
        RightChild = null;
        Value = 0;
    }

    public void SendValueRight(int value){
        Branch from = this;
        Branch to = Parent;
        while(to!.RightChild == from){
            from = to;
            to = to.Parent;
            if(to == null){
                return;
            }
        }
        to = to.RightChild;
        while(to.HasChild){
            to = to.LeftChild;
        }
        to.Value += value;
    }

    public void SendValueLeft(int value){
        Branch from = this;
        Branch to = Parent;
        while(to!.LeftChild == from){
            from = to;
            to = to.Parent;
            if(to == null){
                return;
            }
        }
        to = to.LeftChild;
        while(to.HasChild){
            to = to.RightChild;
        }
        to.Value += value;
    }

    public int GetMagnitude()
    {
        if (HasChild) {
            return 3* LeftChild!.GetMagnitude() + 2 * RightChild!.GetMagnitude();
        }
        else {
            return Value;
        }
    }

}