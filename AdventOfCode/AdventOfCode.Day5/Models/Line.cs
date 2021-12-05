using System;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode.Day5.Models
{
    public class Line
    {
        private readonly int _startX;
        private readonly int _startY;
        private readonly int _endX;
        private readonly int _endY;
        private readonly int _xDirection;
        private readonly int _yDirection;

        public Line(string startX, string startY, string endX, string endY)
        {
            _startX = int.Parse(startX);
            _startY = int.Parse(startY);
            _endX = int.Parse(endX);
            _endY = int.Parse(endY);
            _xDirection = _startX <= _endX ? 1 : -1;
            _yDirection = _startY <= _endY ? 1 : -1;
        }

        public List<Vector2> GetSimplePoints()
        {
            List<Vector2> points = new List<Vector2>();

            if (_startX == _endX || _startY == _endY)
            {
                for (int x = _startX; x != _endX + _xDirection; x += _xDirection)
                {
                    for (int y = _startY; y != _endY + _yDirection; y += _yDirection)
                    {
                        points.Add(new Vector2(x, y));
                    }
                }
            }

            return points;
        }

        public List<Vector2> GetAllPoints()
        {
            List<Vector2> points = new List<Vector2>();

            if (_startX == _endX || _startY == _endY)
            {
                for (int x = _startX; x != _endX + _xDirection; x += _xDirection)
                {
                    for (int y = _startY; y != _endY + _yDirection; y += _yDirection)
                    {
                        points.Add(new Vector2(x, y));
                    }
                }
            }
            else
            {
                int size = (_endX - _startX) * _xDirection + 1;

                for (int i = 0; i < size; i++)
                {
                    points.Add(new Vector2(_startX + i * _xDirection, _startY + i * _yDirection));
                }
            }

            return points;
        }
    }
}
