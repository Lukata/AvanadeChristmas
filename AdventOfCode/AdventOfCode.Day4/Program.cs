using AdventOfCode.Day4.Models;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            Bingo bingo = InputReader.ReadFile();

            //PartOne(bingo);
            PartTwo(bingo);
        }

        private static void PartOne(Bingo bingo)
        {
            foreach(int number in bingo.Numbers)
            {
                foreach(Board board in bingo.Boards)
                {
                    board.Mark(number);

                    if(board.IsFinish())
                    {
                        int score = board.GetResultSum() * number;
                        Console.WriteLine(score);
                        Console.ReadLine();
                    }
                }
            }
        }

        private static void PartTwo(Bingo bingo)
        {
            Board lastWiningBoard = new Board();
            int lastWiningNumber = 0;
            foreach (int number in bingo.Numbers)
            {
                for(int i = 0; i < bingo.Boards.Count; i++)
                {
                    bingo.Boards[i].Mark(number);

                    if (bingo.Boards[i].IsFinish())
                    {
                        lastWiningBoard = bingo.Boards[i];
                        lastWiningNumber = number;
                        bingo.Boards.RemoveAt(i);
                        i--;
                        Console.WriteLine(bingo.Boards.Count);
                    }
                }
                if(bingo.Boards.Count == 0)
                {
                    break;
                }
            }

            int score = lastWiningBoard.GetResultSum() * lastWiningNumber;
            Console.WriteLine(score);
            Console.ReadLine();
        }
    }
}
