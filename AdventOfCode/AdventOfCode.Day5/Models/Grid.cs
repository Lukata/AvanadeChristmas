using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode.Day5.Models
{
    public class Grid
    {
        private readonly int[,] _diagram;

        public Grid()
        {
            _diagram = new int[1000, 1000];
        }

        public void AddPoints(List<Vector2> points)
        {
            foreach (Vector2 point in points)
            {
                _diagram[(int)point.X, (int)point.Y]++;
            }
        }

        public int GetSum()
        {
            int sum = 0;

            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    if (_diagram[x, y] >= 2)
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }
    }
}
