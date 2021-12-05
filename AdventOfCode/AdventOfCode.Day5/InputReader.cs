using AdventOfCode.Day5.Models;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day5
{
    public static class InputReader
    {
        public static List<Line> ReadFile()
        {
            string[] inputs = File.ReadAllLines("input.txt");
            List<Line> lines = new List<Line>();

            foreach(string input in inputs)
            {
                string[] coodinates = input.Split(" -> ");
                string[] startPoint = coodinates[0].Split(',');
                string[] endPoint = coodinates[1].Split(',');

                lines.Add(new Line(startPoint[0], startPoint[1], endPoint[0], endPoint[1]));
            }
            
            return lines;
        }
    }
}
