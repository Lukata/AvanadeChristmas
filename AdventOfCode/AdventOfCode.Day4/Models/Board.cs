using System.Collections.Generic;

namespace AdventOfCode.Day4.Models
{
    public class Board
    {
        private readonly int _size;

        public List<int> Numbers { get; set; }
        public List<int> UnmarkedNumbers { get; set; }

        public Board()
        {

        }

        public Board(int size, string[] numbers)
        {
            Numbers = new List<int>();
            UnmarkedNumbers = new List<int>();
            _size = size;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Numbers.Add(int.Parse(numbers[col + row * size]));
                    UnmarkedNumbers.Add(1);
                }
            }
        }

        public void Mark(int value)
        {
            if(Numbers.Contains(value))
            {
                int id = Numbers.IndexOf(value);
                UnmarkedNumbers[id] = 0;
            }
        }

        public bool IsFinish()
        {
            int[] colSums = new int[_size];
            for (int row = 0; row < _size; row++)
            {
                int sum = 0;
                for (int col = 0; col < _size; col++)
                {
                    sum += UnmarkedNumbers[col + row * _size];
                    colSums[col] += UnmarkedNumbers[col + row * _size];
                }

                if(sum == 0)
                {
                    return true;
                }
            }

            foreach(int colSum in colSums)
            {
                if(colSum == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public int GetResultSum()
        {
            int sum = 0;
            for(int i = 0; i < Numbers.Count; i++)
            {
                sum += Numbers[i] * UnmarkedNumbers[i];
            }

            return sum;
        }
    }
}
