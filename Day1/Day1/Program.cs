using System;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "values.txt";
            if (!File.Exists(file))
            {
                Console.WriteLine("File doesn't exist");
                return;
            }

            int increased = 0;
            int index = 1;
            var listValues = File.ReadLines(file).ToList();
            foreach (string value in listValues.Skip(1))
            {
                if(int.TryParse(value, out int current) && int.TryParse(listValues[index - 1], out int previous))
                    if (current > previous) increased++;
                index++;
            }

            Console.Write($"Total increased {increased}");

            return;
        }
    }
}
