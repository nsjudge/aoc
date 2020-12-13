using System;
using System.Collections.Generic;
using System.IO;

namespace day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int>();
            using (var reader = new StreamReader(args[0]))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    if (int.TryParse(line, out int value))
                    {
                        nums.Add(value);
                    }
                }
            }

            for (int first = 0; first < nums.Count - 1; ++first)
            {
                int firstVal = nums[first];
                for (int second = first + 1; second < nums.Count; ++second)
                {
                    int secondVal = nums[second];
                    int sum = firstVal + secondVal;
                    Console.WriteLine($"{firstVal} + {secondVal} = {sum}");
                    if (sum == 2020)
                    {
                        Console.WriteLine($"{firstVal} * {secondVal} = {firstVal * secondVal}");
                        return;
                    }
                }
            }

            Console.WriteLine("No answer!");
        }
    }
}
