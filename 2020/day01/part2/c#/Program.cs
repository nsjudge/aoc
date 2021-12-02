using System;
using System.Collections.Generic;
using System.IO;

namespace day1p2
{
    class Program
    {
        static void Main(string[] args)
        {
            var numList = new List<int>();
            using (var reader = new StreamReader(args[0]))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    if (Int32.TryParse(line, out int val))
                    {
                        numList.Add(val);
                    }
                }
            }

            numList.Sort();
            for (int i = 0; i < numList.Count - 2; ++i)
            {
                Int64 a = numList[i];
                for (int j = i + 1; j < numList.Count - 1; ++j)
                {
                    Int64 b = numList[j];
                    Int64 sumB = a + b;
                    if (sumB > 2020)
                    {
                        break;
                    }

                    for (int k = j + 1; k < numList.Count; ++k)
                    {
                        Int64 c = numList[k];
                        Int64 sumC = sumB + c;
                        if (sumC > 2020)
                        {
                            break;
                        }

                        if (sumC == 2020)
                        {
                            Console.WriteLine(a * b * c);
                            return;
                        }
                    }
                }
            }
        }
    }
}
