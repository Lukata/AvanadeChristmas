using AdventOfCode.Day4.Models;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Day4
{
    public static class InputReader
    {
        public static Bingo ReadFile()
        {
            string[] inputs = File.ReadAllLines("input.txt");
            int size = 5;

            string[] numbersString = inputs[0].Split(',');
            int[] numbers = new int[numbersString.Length];

            for (int i = 0; i < numbersString.Length; i++)
            {
                numbers[i] = int.Parse(numbersString[i]);
            }

            List<Board> boards = new List<Board>();

            for (int i = 2; i < inputs.Length; i += size + 1)
            {
                List<string> boardNumbers = new List<string>();

                for (int j = 0; j < size; j++)
                {
                    boardNumbers.AddRange(inputs[i + j].Split(" "));
                }
                boardNumbers.RemoveAll(v => v == "");

                boards.Add(new Board(size, boardNumbers.ToArray()));
            }

            Bingo bingo = new Bingo(numbers, boards);
            return bingo;
        }
    }
}
