using System;
using System.Collections.Generic;

namespace AdventOfCode.Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = InputReader.ReadFile();

            //PartOne(inputs);
            PartTwo(inputs);
        }

        private static void PartOne(string[] inputs)
        {
            int[] gammaArray = new int[inputs[0].Length];
            int[] epsilonArray = new int[inputs[0].Length];
            foreach (string input in inputs)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    gammaArray[i] += input[i] - '0';
                }
            }

            for (int i = 0; i < gammaArray.Length; i++)
            {
                gammaArray[i] = gammaArray[i] / (inputs.Length / 2);
                epsilonArray[i] = 1 - gammaArray[i];
            }

            string gammaBinary = string.Join("",gammaArray);
            string epsilonBinary = string.Join("",epsilonArray);

            int gamma = Convert.ToInt32(gammaBinary, 2);
            int epsilon = Convert.ToInt32(epsilonBinary, 2);

            Console.WriteLine(gamma * epsilon);
            Console.ReadLine();
        }

        private static void PartTwo(string[] inputs)
        {
            int oxygenGenerator = FindRating(inputs, 0);
            int co2Scrubber = FindRating(inputs, 1);

            Console.WriteLine(oxygenGenerator * co2Scrubber);
            Console.ReadLine();
        }

        private static int FindRating(string[] inputs, int rating)
        {
            for(int i = 0; i < inputs[0].Length; i++)
            {
                inputs = FilterByCommon(inputs, rating, i);
                if(inputs.Length == 1)
                {
                    break;
                }
            }

            return Convert.ToInt32(inputs[0], 2);
        }

        private static string[] FilterByCommon(string[] inputs, int rating, int id)
        {
            int sum = 0;
            List<string> inputsFiltered = new List<string>();

            foreach (string input in inputs)
            {
                sum += input[id] - '0';
            }

            int bitCriteria = Math.Abs(rating - sum / ((inputs.Length + 1) / 2));
            foreach (string input in inputs)
            {
                if(input[id] - '0' == bitCriteria)
                {
                    inputsFiltered.Add(input);
                }
            }

            return inputsFiltered.ToArray();
        }
    }
}
