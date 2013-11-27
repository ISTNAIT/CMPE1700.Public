using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            //Number of items to search
            int dataSize = 100000000;
            //Location of item
            int index = -1;
            //How long a search takes (ms)
            double time = 0;

            //Create list full of randomness
            List<int> data = new List<int>(dataSize);
            Random rand = new Random();
            for (int i = 0; i < dataSize; ++i)
                data.Add(rand.Next(dataSize));

            //Use a random search value
            int value = rand.Next(dataSize);

            //Linear search
            index = LinearSearch(data, value, out time);
            Console.WriteLine("Linear search took {0} milliseconds to find the value {1} at index {2}.", time,value,index);

            //Sort
            Sort(data,out time);
            Console.WriteLine("Sorting took {0} milliseconds.",time);

            //Binary search
            index = BinarySearch(data, value, 0, data.Count-1, out time);
            Console.WriteLine("Binary search took {0} milliseconds to find the value {1} at index {2}.", time, value, index);
        }

        //Uses linear search on data to find value.  Returns index of found
        //item, or -1 on failure.  Output parameter time is number of milli-
        //seconds for search.
        static int LinearSearch(List<int> data, int value, out double time)
        {
            DateTime startTime = DateTime.Now;
            int location = -1;
            int index = 0;
            
            //Search the list
            while (index < data.Count && data[index] != value) ++index;

            //Found?
            if (index < data.Count) location = index;

            //Calculate duration
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            time = duration.TotalMilliseconds;

            //return location
            return location;
        }

        //Recursive binary search on data to find value.  Returns index of
        //found value or -1 on failure.  Reference parameter time is number
        //of milliseconds for search.  Startindex is index value of first item
        //to consider.  Stopindex is index value of last item to consider.
        static int BinarySearch(List<int> data, int value, int startIndex, int stopIndex, out double time)
        {
            DateTime startTime = DateTime.Now;
            int location = -1; //Return value
            int midpoint = startIndex + stopIndex/2 - startIndex/2;  //Weird math for midpoint to avoid overflow

            if (stopIndex < startIndex) //shouldn't happen
                location = -1;
            
            else if(stopIndex == startIndex) //Only one item to consider
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

            //Calculate duration
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            time = duration.TotalMilliseconds;

            return location;
        }

        //Wrapper function to time sorting a List.
        static void Sort(List<int> data, out double time)
        {
            DateTime startTime = DateTime.Now;

            data.Sort();

            //Calculate duration
            DateTime stopTime = DateTime.Now;
            TimeSpan duration = stopTime - startTime;
            time = duration.TotalMilliseconds;
        }

            
    }
}
