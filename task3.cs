using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace cSharpTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            String line = " ";

            int cash_desks = 5;

            List<float> max_index_of_time = new List<float>();

            List<float> max_time = new List<float>();

            float max = -1;
            int index = -1;


            for (int i = 0; i < cash_desks; i++)
            {
                StreamReader k = new StreamReader(String.Join(" ", args[i]));

                line = k.ReadLine();

                List<float> termsList = new List<float>();

                termsList.Add((float)Convert.ToDouble(line));

                while (line != null)
                {
                    line = k.ReadLine();
                    if (line != null)
                    {
                        termsList.Add((float)Convert.ToDouble(line));
                    }
                }

                for (int j = 0; j < termsList.Count; j++)
                {
                    if (max <= termsList[j])
                    {
                        max = termsList[j];
                        index = j;
                    }
                }

                max_index_of_time.Add(index);
                max_time.Add(max);
            }

            max = -1;
            index = -1;

            for (int j = 0; j < max_time.Count; j++)
            {
                if (max <= max_time[j])
                {
                    max = max_time[j];
                    index = j;
                }
            }

            Console.WriteLine("Интервал времени, когда в магазине было наибольшее количество посетителей за день (в минутах):");
            Console.WriteLine((max_index_of_time[index] + 1) * 30);
            Console.WriteLine("Номер интервала:");
            Console.WriteLine(max_index_of_time[index] + 1);

            Console.WriteLine();

            for (int j = 0; j < max_index_of_time.Count; j++)
            {
                Console.Write("номер интервала, в котором было наибольшее число посетителей в очередях магазина на кассe: ");
                Console.WriteLine(j + 1);
                Console.WriteLine(max_index_of_time[j]+1);
            }

            Console.ReadLine();
        }
    }
}
