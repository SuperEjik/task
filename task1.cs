using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ConsoleAppCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            String line;

            StreamReader sr = new StreamReader(String.Join(" ", args));

            line = sr.ReadLine();

            List<float> termsList = new List<float>();

            termsList.Add((float)Convert.ToDouble(line));
            while (line != null)
            {
                line = sr.ReadLine();
                if (line != null)
                {
                    termsList.Add((float)Convert.ToDouble(line));
                }
            }

            Console.WriteLine("{0:F2}", Percentile(termsList, 0.8));

            termsList.Sort();
            float sort = termsList[(termsList.Count / 2)];
            Console.WriteLine("{0:F2}", sort);

            float max = termsList.Max();
            Console.WriteLine("{0:F2}", max);

            float min = termsList.Min();
            Console.WriteLine("{0:F2}", min);

            float ave = termsList.Average();
            Console.WriteLine("{0:F2}", ave);


            Console.ReadKey();
        }

        public static double Percentile(IEnumerable<float> seq, double percentile)
        {
            var elements = seq.ToArray();
            Array.Sort(elements);
            double realIndex = percentile * (elements.Length);
            int index = (int)realIndex;
            double frac = realIndex - index;
            if (index + 1 < elements.Length)
                return elements[index] * (1 - frac) + elements[index] * frac;
            else
                return elements[index];
        }
    }
}
