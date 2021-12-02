using System;

namespace AdventOfCode.Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputs = InputReader.ReadFile();

            PartTwo(inputs);
        }

        private static void PartOne(int[] inputs)
        {
            int count = 0;

            for (int i = 1; i < inputs.Length; i++)
            {
                if (inputs[i - 1] < inputs[i])
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        private static void PartTwo(int[] inputs)
        {
            int count = 0;

            for (int i = 1; i < inputs.Length - 2; i++)
            {
                int commomPart = inputs[i] + inputs[i + 1];
                int firtPart = inputs[i - 1] + commomPart;
                int secondPart = inputs[i + 2] + commomPart;

                if (firtPart < secondPart)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
