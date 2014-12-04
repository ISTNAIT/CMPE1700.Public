using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_12___SearchSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 1000; //Maximum value in list
            int count = 10; //Number of items in list
            int value = 0; //Value to search for
            int location = 0; //Location of found value
            Random r = new Random();
            List<int> Values = new List<int>(count); //My list of values

            //Fill with random numbers
            for (int i = 0; i < count; ++i)
                Values.Add(r.Next(max));
            PrintList(Values);
            //Sort 'em
            SelectionSort(Values);
            PrintList(Values);

            do
            {
                Console.Write("Search for what value (negative to exit)?");
                try
                {
                    value = int.Parse(Console.ReadLine());
                    if (value < 0) break;
                    //Search whole list
                    location = BinarySearch(Values, value, Values.Count - 1, 0);
                }
                catch
                {
                    Console.Write("I didn't understand that. ");
                    location = -1;
                }
                if (location >= 0)
                    Console.WriteLine("Found at position " + location);
                else
                    Console.WriteLine("Not found.");
            } 
            while (true);
        }

        static void PrintList(List<int> Values)
        {
            foreach(int i in Values)
                Console.Write(i + " ");
            Console.WriteLine();
        }

        static List<int> SelectionSort(List<int> Values)
        {
            int maxLoc = 0; //Location of the largest value found on the current pass
            //Loop from last item to second item (these are the place I'm moving things to)
            for (int i = Values.Count - 1; i > 0; --i)
            {
                //Find the largest between 0 and i
                maxLoc = 0;
                for (int j = 1; j <= i; ++j)
                    if (Values[j] > Values[maxLoc])
                        maxLoc = j;
                //Maxloc should now be the index of the largest value in subset
                //Swap em
                if (i != maxLoc) //No need to swap if already correct
                {
                    int temp = Values[i];
                    Values[i] = Values[maxLoc];
                    Values[maxLoc] = temp;
                }
            }
            return Values;
        }

        //Binary search list for value between indices top and bottom
        static int BinarySearch(List<int> Values, int value, int top, int bottom)
        {
            int middleLoc = 0;
            //Base cases
            if (top < bottom) //Empty list 
                return -1;
            if (top == bottom) //Exactly one item
                if (Values[top] == value) //Found it!
                    return top;
                else
                    return -1;
            //Now, check if the middle value is what I'm looking for
            middleLoc = (top + bottom) / 2;
            if (Values[middleLoc] == value) //Found it!
                return middleLoc;
            else if (Values[middleLoc] > value) // The value should be before middleloc
                return BinarySearch(Values, value, middleLoc - 1, bottom);
            else if (Values[middleLoc] < value) // The value should be in the top half
                return BinarySearch(Values, value, top, middleLoc + 1);
            return -1;
        }
    }
}
