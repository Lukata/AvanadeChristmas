using System.Collections.Generic;

namespace AdventOfCode.Day4.Models
{
    public class Bingo
    {
        public int[] Numbers { get; set; }
        public List<Board> Boards { get; set; }

        public Bingo(int[] numbers, List<Board> boards)
        {
            Numbers = numbers;
            Boards = boards;
        }
    }
}
