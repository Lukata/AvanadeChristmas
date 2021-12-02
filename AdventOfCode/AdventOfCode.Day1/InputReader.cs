using System.IO;

namespace AdventOfCode.Day1
{
    public static class InputReader
    {
        public static int[] ReadFile()
        {
            string[] lines = File.ReadAllLines("input.txt");
            int[] inputs = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                inputs[i] = int.Parse(lines[i]);
            }

            return inputs;
        }
    }
}
