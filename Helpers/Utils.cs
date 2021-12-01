using System;

namespace AdventOfCode
{
    public static class Utils
    {
        public static int[] ConvertToInts(this string[] data)
        {
            return Array.ConvertAll(data, s => int.Parse(s));
        }

    }
}
