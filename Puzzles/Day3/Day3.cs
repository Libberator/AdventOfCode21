using System.Collections.Generic;
using System.Linq;

namespace Puzzles;

public class Day3 : Puzzle<List<string>>
{
    private const char One = '1';
    private const char Zero = '0';

    public override List<string> Convert(IEnumerable<string> data) => data.ToList();

    public override int SolvePart1(List<string> data)
    {
        var gamma = 0; // more common
        var epsilon = 0; // less common

        var totalCount = data.Count;
        var lengthOfLine = data[0].Length;

        for (int i = 0; i < lengthOfLine; i++)
        {
            //int increment = (int)Math.Pow(2, i);  // does the same thing, but more human readable
            int increment = 1 << (lengthOfLine - i - 1);  // bitwise is a bit (hehe) faster

            var ones = data.Count(line => line[i] == One);

            if (ones > totalCount / 2) { gamma += increment; }
            else { epsilon += increment; }
        }

        return gamma * epsilon;
    }

    public override int SolvePart2(List<string> data)
    {
        var oxygenRating = TakeMore(data, 0); // takes side with more
        var scrubberRating = TakeFewer(data, 0); // takes side with fewer
        
        var lengthOfLine = data[0].Length;

        for (int i = 1; i < lengthOfLine; i++)
        {
            if (GetCount(oxygenRating) != 1) 
            {
                oxygenRating = TakeMore(oxygenRating, i);
            }
            
            if (GetCount(scrubberRating) != 1)
            {
                scrubberRating = TakeFewer(scrubberRating, i);
            }
        }

        return BinaryStringToInt(oxygenRating.First()) * BinaryStringToInt(scrubberRating.First());
    }


    private static IEnumerable<string> TakeMore(IEnumerable<string> input, int index)
    {
        var zeros = input.Where(s => s[index] == Zero);
        var ones = input.Where(s => s[index] == One);

        return zeros.Count() > ones.Count() ? zeros : ones;  // ties go in favor of ones
    }

    private static IEnumerable<string> TakeFewer(IEnumerable<string> input, int index)
    {
        var zeros = input.Where(s => s[index] == Zero);
        var ones = input.Where(s => s[index] == One);

        return zeros.Count() > ones.Count() ? ones : zeros;  // ties go in favor of zeros
    }

    private static int GetCount(IEnumerable<string> input)
    {
        if(!input.TryGetNonEnumeratedCount(out int count)) 
        { 
            count = input.Count(); 
        }
        return count;
    }

    private static int BinaryStringToInt(string s) => System.Convert.ToInt32(s, 2);
}