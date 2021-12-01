using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day1 : Puzzle
    {
        public override bool SolvePart1(string[] data, out int solution)
        {
            int[] dataAsInts = data.ConvertToInts();
            int previousNum = dataAsInts[0];

            solution = 0;
            
            for (int i = 1; i < dataAsInts.Length; i++)
            {
                int currentNum = dataAsInts[i];
                if(currentNum > previousNum)
                {
                    solution++;
                }
                previousNum = currentNum;
            }

            return true;
        }

        public override bool SolvePart2(string[] data, out int solution)
        {
            int[] dataAsInts = data.ConvertToInts();
            int[] window = new int[3] { dataAsInts[0], dataAsInts[1], dataAsInts[2] };
            int previousSum = window.Sum();
            
            solution = 0;
            
            for (int i = 3; i < dataAsInts.Length; i++)
            {
                window[i % 3] = dataAsInts[i];
                int currentSum = window.Sum();
                if(currentSum > previousSum)
                {
                    solution++;
                }
                previousSum = currentSum;
            }
            return true;
        }
    }
}
