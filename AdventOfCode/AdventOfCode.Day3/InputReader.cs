using System.IO;

namespace AdventOfCode.Day3
{
    public static class InputReader
    {
        public static string[] ReadFile()
        {
            string[] inputs = File.ReadAllLines("input.txt");

            return inputs;
        }
    }
}
