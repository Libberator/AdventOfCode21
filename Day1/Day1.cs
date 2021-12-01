using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day1 : Puzzle
    {
        private int _count = 0;
        private int _previousNum;

        public override int Solve(string[] data)
        {
            if (data == null) { return -1; }

            int[] dataAsInts = data.ConvertToInts();

            _previousNum = dataAsInts[0];

            for (int i = 1; i < dataAsInts.Length; i++)
            {
                int currentNum = dataAsInts[i];
                if(currentNum > _previousNum)
                {
                    _count++;
                }
                _previousNum = currentNum;
            }

            return _count;
        }
    }
}
