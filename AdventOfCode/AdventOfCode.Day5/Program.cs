using AdventOfCode.Day5.Models;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Line> lines = InputReader.ReadFile();

            //PartOne(lines);
            PartTwo(lines);
        }

        private static void PartOne(List<Line> lines)
        {
            Grid grid = new Grid();
            foreach(Line line in lines)
            {
                grid.AddPoints(line.GetSimplePoints());
            }

            Console.WriteLine(grid.GetSum());
            Console.ReadLine();
        }

        private static void PartTwo(List<Line> lines)
        {
            Grid grid = new Grid();
            foreach (Line line in lines)
            {
                grid.AddPoints(line.GetAllPoints());
            }

            Console.WriteLine(grid.GetSum());
            Console.ReadLine();
        }
    }
}
