using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles;

public class Day11 : Puzzle
{
    private readonly int[,] _data = new int[10, 10];

    private readonly List<Octopus> _activeOctopuses = new ();
    private int _numberOfFlashes;
    public event Action StepEvent = delegate{};
    public event Action CheckEvent = delegate{};
    public event Action<int, int> FlashEvent = delegate{};
    public void TriggerFlash(int row, int col)
    {
        FlashEvent?.Invoke(row, col);
        _numberOfFlashes++;
    }

    public Day11(string path) : base(path)
    {
        int row = 0;
        foreach (var line in LoadFromFile())
        {
            int col = 0;
            foreach (var letter in line)
            {
                _data[row, col] = letter - '0';
                col++;
            }
            row++;
        }
    }

    private void ResetOctopuses()
    {
        _activeOctopuses.Clear();
        StepEvent = delegate{};
        CheckEvent = delegate{};
        FlashEvent = delegate{};
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                _activeOctopuses.Add(new Octopus(this, _data[i, j], i, j));
            }
        }
    }

    public override int SolvePart1()
    {
        ResetOctopuses();
        _numberOfFlashes = 0;
        for (int i = 0; i < 100; i++)
        {
            StepEvent?.Invoke();
            CheckEvent?.Invoke();            
        }
        return _numberOfFlashes; // 1725
    }

    public override int SolvePart2()
    {
        ResetOctopuses();
        int currentStep = 0;
        while (!_activeOctopuses.All(o => o.HasFlashed))
        {
            currentStep++;
            StepEvent?.Invoke();
            CheckEvent?.Invoke();
        }
        return currentStep; // 308
    }

    public class Octopus
    {
        public bool HasFlashed { get; private set; }
        private int _value;
        private readonly int _row, _col;
        private readonly Day11 _source;

        public Octopus(Day11 source, int value, int row, int col)
        {
            _value = value;
            _row = row;
            _col = col;
            _source = source;
            source.FlashEvent += NeighborFlashed;
            source.StepEvent += Step;
            source.CheckEvent += Check;
        }

        public void Step()
        {
            _value = _value > 9 ? 1 : _value + 1;
            HasFlashed = false;
        }

        public void NeighborFlashed(int row, int col)
        {
            if (!IsWithinRange(row, col)) return;
            _value++;
            Check();
        }

        public void Check()
        {
            if (HasFlashed) return;
            if (_value > 9) Flash();
        }

        public void Flash()
        {
            HasFlashed = true;
            _source.TriggerFlash(_row, _col);
        }

        private bool IsWithinRange(int row, int col)
        {
            return Math.Abs(row - _row) <= 1 && 
                   Math.Abs(col - _col) <= 1 && 
                   !(row == _row && col == _col); // not self
        }
    }
}