using AdventOfCode.Day2.Models;
using System.IO;

namespace AdventOfCode.Day2
{
    public static class InputReader
    {
        public static SubmarineCommand[] ReadFile()
        {
            string[] lines = File.ReadAllLines("input.txt");
            SubmarineCommand[] commands = new SubmarineCommand[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] lineData = lines[i].Split(' ');
                commands[i] = new SubmarineCommand(lineData[0], lineData[1]);
            }

            return commands;
        }
    }
}
