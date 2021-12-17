using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace Puzzles;

public class Day16 : Puzzle<long>
{
    private readonly Dictionary<char, string> Hex2Bin = new(){
        ['0'] = "0000",
        ['1'] = "0001",
        ['2'] = "0010",
        ['3'] = "0011",
        ['4'] = "0100",
        ['5'] = "0101",
        ['6'] = "0110",
        ['7'] = "0111",
        ['8'] = "1000",
        ['9'] = "1001",
        ['A'] = "1010",
        ['B'] = "1011",
        ['C'] = "1100",
        ['D'] = "1101",
        ['E'] = "1110",
        ['F'] = "1111"
    };
    
    private readonly string _data;

    public Day16(string path) : base(path)
    {
        StringBuilder sb = new();
        var line = LoadFromFile().First();

        foreach (var hex in line) {
            sb.Append(Hex2Bin[hex]);
        }
        _data = sb.ToString();
    }

    public override long SolvePart1()
    {
        int index = 0;
        long total = 0;
        Part1PacketUnpacker(_data, ref index, ref total);
        return total;  // 989
    }

    public override long SolvePart2()
    {
        int index = 0;
        long evaluation = Part2PacketUnpacker(_data, ref index);
        return evaluation;  // 7936430475134
    }

    private void Part1PacketUnpacker(string data, ref int index, ref long total)
    {
        var versionNumber = data.Substring(index, 3);
        index += 3;
        var typeID = data.Substring(index , 3);
        index += 3;
        total += Utils.BinaryToInt(versionNumber);

        if (typeID == "100") // literal value
        {
            bool reachedStopBit;
            do
            {
                var chunk = data.Substring(index, 5);
                reachedStopBit = chunk[0] == '0';
                index += 5;
            } while (!reachedStopBit);
            return;
        } 
        // else we have an operator
        var lengthTypeID = data[index];
        index++;

        if (lengthTypeID == '0')
        {
            var subPacketsBitTotal = Utils.BinaryToInt(data.Substring(index, 15));
            index += 15;
            var targetIndex = index + subPacketsBitTotal;
            while (index != targetIndex)
            {
                Part1PacketUnpacker(data, ref index, ref total);
            }
        }
        else
        {
            var QtyOfSubPackets = Utils.BinaryToInt(data.Substring(index, 11));
            index += 11;
            for (int i = 0; i < QtyOfSubPackets; i++)
            {
                Part1PacketUnpacker(data, ref index, ref total);
            }
        }
    }


    private long Part2PacketUnpacker(string data, ref int index)
    {
        var typeID = data.Substring(index + 3, 3);
        index += 6;

        if (typeID == "100") // literal value
        {
            bool reachedStopBit;
            StringBuilder sb = new();
            do
            {
                var chunk = data.Substring(index, 5);
                sb.Append(chunk.AsSpan(1));
                reachedStopBit = chunk[0] == '0';
                index += 5;
            } while (!reachedStopBit);
            return Utils.BinaryToLong(sb.ToString());
        }
        // else we have an operator
        var lengthTypeID = data[index];
        index++;

        if (lengthTypeID == '0')
        {
            var targetIndex = index + Utils.BinaryToInt(data.Substring(index, 15));
            index += 15;
            switch (typeID)
            {
                case "000":  // sum packets
                    long sum = 0;
                    while (index != targetIndex){
                        sum += Part2PacketUnpacker(data, ref index);
                    }
                    return sum;

                case "001":  // product packets = 1 * N
                    long product = 1;
                    while (index != targetIndex){
                        product *= Part2PacketUnpacker(data, ref index);
                    }
                    return product;

                case "010":  // minimum packets
                    long minimum = int.MaxValue;
                    while (index != targetIndex){
                        minimum = Math.Min(minimum, Part2PacketUnpacker(data, ref index));
                    }
                    return minimum;

                case "011":  // maximum packets
                    long maximum = 0;
                    while (index != targetIndex){
                        maximum = Math.Max(maximum, Part2PacketUnpacker(data, ref index));
                    }
                    return maximum;
            }
        }
        
        else if (lengthTypeID == '1')
        {
            var QtyOfSubPackets = Utils.BinaryToInt(data.Substring(index, 11));
            index += 11;
            switch (typeID)
            {
                case "000":  // sum packets
                    long sum = 0;
                    for (int i = 0; i < QtyOfSubPackets; i++){
                        sum += Part2PacketUnpacker(data, ref index);
                    }
                    return sum;

                case "001":  // product packets = 1 * N
                    long product = 1;
                    for (int i = 0; i < QtyOfSubPackets; i++){
                        product *= Part2PacketUnpacker(data, ref index);
                    }
                    return product;

                case "010":  // minimum packets
                    long minimum = int.MaxValue;
                    for (int i = 0; i < QtyOfSubPackets; i++){
                        minimum = Math.Min(minimum, Part2PacketUnpacker(data, ref index));
                    }
                    return minimum;

                case "011":  // maximum packets
                    long maximum = 0;
                    for (int i = 0; i < QtyOfSubPackets; i++){
                        maximum = Math.Max(maximum, Part2PacketUnpacker(data, ref index));
                    }
                    return maximum;
            }
        }

        long a = Part2PacketUnpacker(data, ref index);
        long b = Part2PacketUnpacker(data, ref index);
        if (typeID == "101") { // greater than packets
            return a > b ? 1 : 0;
        }
        else if (typeID == "110") { // less than packets
            return a < b ? 1 : 0;
        }
        else if (typeID == "111") { // equal to
            return a == b ? 1 : 0;
        }
        
        return -1;
    }
}