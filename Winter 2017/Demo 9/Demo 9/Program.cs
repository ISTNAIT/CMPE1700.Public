using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Demo_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            const int domain = 100000000;
            int[] test = new int[domain];
            for (int i = 0; i < domain; ++i)
                test[i] = i;
            for (int i = 0; i < 10; ++i)
            {
                int count = 0;
                int key = r.Next(domain);
                Console.WriteLine("Value " + key + " found at location " +
                    BSearch(test, 0, test.Length - 1, key, ref count) + " in " +
                    count + " inspections.");
            }


            if (Debugger.IsAttached) Console.ReadLine();
        }

        static int BSearch(int[] array, int left, int right, int key, ref int count)
        {
            count++;
            //Base case
            if (right == left) return (array[left] == key) ? left : -1;
            if ((right - left) < 1) return -1;

            //Normal case
            //Middle index 
            int index = left + (right - left) / 2;
            if (array[index] == key) return index;
            else if (array[index] > key)
                return BSearch(array, left, index - 1, key, ref count);
            else
                return BSearch(array, index + 1, right, key, ref count);
        }
    }
}
