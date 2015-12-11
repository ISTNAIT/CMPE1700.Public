using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Demo_7
{
    class Program
    {
        //Quicksort of a List<int>
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            const int size = 100000;
            Random r = new Random();
            //Create a list and fill with random values
            List<int> values = new List<int>(size);
            for (int i = 0; i < size; ++i)
                values.Add(i);//r.Next(size));
            PrintList(values);

            Console.WriteLine();

            sw.Start();
            QuickSort(values, 0, values.Count - 1);
            sw.Stop();
            PrintList(values);
            Console.WriteLine("Duration: " + sw.ElapsedMilliseconds);

            Console.ReadKey();
        }

        public static List<int> QuickSort(List<int> values, int leftIndex, int rightIndex)
        {
            if (values == null || leftIndex >= rightIndex)
                return values;

            if (leftIndex == rightIndex - 1) //Exactly two items
            {
                if (values[leftIndex] > values[rightIndex])
                    Swap(values, leftIndex, rightIndex);
                return values;
            }
            //If here, have at least three items.  Create and assign pointers.
            int pivot = leftIndex;
            int left = leftIndex + 1;
            int right = rightIndex;

            //Begin advancing pointers
            while(left < right) //Pointers are separated
            {
                while (values[right] > values[pivot] && right > pivot)
                    right--;
                while (values[left] <= values[pivot] && left < right)
                    left++;
                if (left < right)
                    Swap(values, left, right);
            }

            //I've found the location for my pivot
            //Check to make sure that the pivot isn't already where it needs to be
            if (right == pivot + 1 && values[right] >= values[pivot]) //correct
                right--;
            else
                Swap(values, pivot, right);

            //Recursive step
            QuickSort(values, leftIndex, right - 1);
            QuickSort(values, right + 1, rightIndex);

            return values;
        }

        public static void Swap(List<int> values, int index1, int index2)
        {
            int temp = values[index1];
            values[index1] = values[index2];
            values[index2] = temp;
        }


        public static void PrintList(List<int> values)
        {
            //foreach (int i in values)
                //Console.Write(i + " ");
            Console.WriteLine();
            Console.WriteLine("Collection is " + (IsSorted(values) ? " " : " not ") + "sorted");
        }

        public static bool IsSorted(List<int> values)
        {
            int i = 0;
           
            while (i < values.Count - 1)
            {
                if (values[i] >  values[i + 1])
                    return false;
                ++i;
            }
            return true;
        }
    }
}
