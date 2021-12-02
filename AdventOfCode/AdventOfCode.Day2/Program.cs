using AdventOfCode.Day2.Enums;
using AdventOfCode.Day2.Models;
using System;

namespace AdventOfCode.Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            SubmarineCommand[] commands = InputReader.ReadFile();

            //PartOne(commands);
            PartTwo(commands);
        }

        private static void PartOne(SubmarineCommand[] commands)
        {
            int horizontalPosition = 0;
            int verticalPosition = 0;

            foreach(var command in commands)
            {
                switch(command.Direction)
                {
                    case EDirection.forward:
                        horizontalPosition += command.Units;
                        break;
                    case EDirection.up:
                        verticalPosition -= command.Units;
                        break;
                    case EDirection.down:
                        verticalPosition += command.Units;
                        break;
                }
            }

            Console.WriteLine(horizontalPosition * verticalPosition);
        }

        private static void PartTwo(SubmarineCommand[] commands)
        {
            int horizontalPosition = 0;
            int verticalPosition = 0;
            int aim = 0;

            foreach (var command in commands)
            {
                switch (command.Direction)
                {
                    case EDirection.forward:
                        horizontalPosition += command.Units;
                        verticalPosition += command.Units * aim;
                        break;
                    case EDirection.up:
                        aim -= command.Units;
                        break;
                    case EDirection.down:
                        aim += command.Units;
                        break;
                }
            }

            Console.WriteLine(horizontalPosition * verticalPosition);
        }
    }
}
