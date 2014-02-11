using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SearchComparison
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int dataSize = int.MaxValue/4;
            int index = -1;
            double time = 0;

            List<int> data = new List<int>(dataSize);
            Random rand = new Random();
            for (int i = 0; i < dataSize; ++i)
                data.Add(rand.Next(dataSize));

            int value = rand.Next(dataSize); //Value to search for

            //Linear
            index = LinearSearch(data, value, out time);
            Console.WriteLine("Linear search took {0} milliseconds to find the value {1} at location {2}", time,value,index);

            //Sort
            Sort(data,out time);
            Console.WriteLine("Sorting {0} items took {1} milliseconds.", dataSize,time);

            //Binary
            index = BinarySearch(data,value,0,data.Count-1,out time);
            Console.WriteLine("Binary search took {0} milliseconds to find the value {1} at location {2}", time,value,index);
        }

        private static int LinearSearch(List<int> data, int value, out double time)
        {
            //Current time
            DateTime startTime = DateTime.Now;

            int location = -1;
            int index = 0;

            while (index < data.Count && data[index] != value) ++index;
            if (index < data.Count) location = index;

            //Elapsed time
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            time = duration.TotalMilliseconds;

            return location;
        }

        private static int BinarySearch(List<int> data, int value, int startIndex, int stopIndex, out double time)
        {
            //Current time
            DateTime startTime = DateTime.Now;
            int location = -1;
            int midpoint = startIndex/2 + stopIndex/2;

            if (stopIndex < startIndex) //No items to check
                location = -1;
            else if (stopIndex == startIndex) //One item to check
                if (data[startIndex] == value)
                    location = startIndex;
                else
                    location = -1;
            else if (data[midpoint] == value)
                location = midpoint;
            else if (data[midpoint] < value)
                location = BinarySearch(data, value, midpoint + 1, stopIndex, out time);
            else if (data[midpoint] > value)
                location = BinarySearch(data, value, startIndex, midpoint - 1, out time);

            //Elapsed time
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            time = duration.TotalMilliseconds;

            return location;
        }

        private static void Sort(List<int> data, out double time)
        {
            //Current time
            DateTime startTime = DateTime.Now;

            data.Sort();

            //Elapsed time
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            time = duration.TotalMilliseconds;
        }
    }
}