using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Demo_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            const int size = 10;

            for (int i = 0; i < 100; ++i)
            {
                int[] data = new int[size];
                for (int j = 0; j < size; ++j)
                    data[j] = r.Next(size);
                QSort(data, 0, size - 1);
                if (!pSorted(data))
                {
                    Console.WriteLine();
                    PrintData(data);
                }
                else Console.Write(".");
            }

            if (Debugger.IsAttached) Console.ReadLine();
        }

        static int[] QSort(int[] data, int first, int last)
        {
            int l, r, p;
            //Recursion exit
            if (last - first < 2) return data;

            //Other recursion exit
            if (last-first ==2)
            {
                if (data[first] > data[last]) Swap(data, first, last);
                return data;
            }

            //I have at least three items.

            //(1) Set pointers
            p = first;
            l = first + 1;
            r = last;

            //(2) Find intersections
            do
            {
                while (r>l && data[r] > data[p]) r--;
                while (l<r && data[l] <= data[p]) l++;
                
                if (r > l)
                    Swap(data, r, l);


            }
            while (r > l);

            //(3) Done partitioning, swap pivot into location.

            //Special case: pivot is already in the correct location
            if (r == p + 1 && data[r] >= data[p])
                r--; //Need to move r onto pivot, so that the original r gets sorted
            else
                Swap(data, r, p);

            //Recurse
            QSort(data, first, r - 1); //Sort left sublist
            QSort(data, r + 1, last); //Sort right sublist

            return data;
        }

        static void Swap(int[] data, int ix1, int ix2 )
        {
            if (ix1 < 0 || ix2 < 0)
                throw new ArgumentOutOfRangeException("Do the rules of the universe mean nothing to you?");

            if (ix1 > data.Length - 1 || ix2 > data.Length - 1)
                throw new ArgumentOutOfRangeException("Dude.  Seriously?");

            int temp = data[ix1];
            data[ix1] = data[ix2];
            data[ix2] = temp;
        }

        static bool pSorted (int[] data)
        {
            for (int i = 0; i < data.Length - 1; ++i)
                if (data[i] > data[i + 1]) return false;
            return true;
        }

        static void PrintData(int[] data)
        {
            foreach (int i in data)
                Console.Write(i + " ");
            Console.WriteLine();
        }
    }
}
