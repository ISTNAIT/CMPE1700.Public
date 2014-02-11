using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            List<int> l = new List<int>(10);
            for (int i = 0; i < 79; ++i)
                l.Add(r.Next(100));
            PrintEm(l.ToArray());
            Console.WriteLine("Capacity = " + l.Capacity);
            Console.WriteLine("Count = " + l.Count);
            Console.WriteLine("Total storage = " + l.Count * sizeof(int) + " bytes");
            Console.WriteLine("Efficiency = " + (double)l.Count / l.Capacity * 100 +"%");

            l.Sort();
            PrintEm(l.ToArray());

            l.RemoveAt(0);
            l.RemoveRange(0, 10);
            l.AddRange(new int[]{0,0,0,0,0,0,0,0,0});
            l.Insert(0, 100000);

            PrintEm(l.ToArray());
        }

        static void PrintEm(int [] array)
        {
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }
    }
}
