using AdventOfCode.Day2.Enums;
using System;

namespace AdventOfCode.Day2.Models
{
    public class SubmarineCommand
    {
        public EDirection Direction { get; set; }
        public int Units { get; set; }

        public SubmarineCommand(string direction, string units)
        {
            Direction = (EDirection) Enum.Parse(typeof(EDirection), direction);
            Units = int.Parse(units);
        }
    }
}
