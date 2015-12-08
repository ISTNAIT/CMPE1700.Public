using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int collSize = 1000;
            

            //Create a random array
            int[] values = new int[collSize];
            for (int i = 0; i < collSize; ++i)
                values[i] = r.Next(collSize);

            //Print 'em
            Console.WriteLine();
            Console.WriteLine("Array\n====");
            PrintArray(values);
            SelectionSort(values);
            PrintArray(values);
            Console.WriteLine("Array is " + (isSorted(values) ? "sorted." : "not sorted."));

            //create a random list
            Node head = null;
            for(int i = 0; i < collSize; ++i)
            {
                //just going to add to head
                Node newHead = new Node();
                newHead.Value = r.Next(collSize);
                newHead.Next = head;
                head = newHead;
            }
            //Print 'em
            Console.WriteLine();
            Console.WriteLine("List\n====");
            PrintList(head);

            //Pause
            Console.ReadKey();

        }

        //Sort an array with selection sort
        public static int[] SelectionSort(int[] values)
        {
            //for every place in value
            for (int i = 0; i < values.Length; ++i)
            {
                //find the smallest element in the unsorted part
                //assume the first one is smallest
                int smalloc = i; //Tracking location, not value
                for(int j = i; j<values.Length; ++j)
                    if (values[j] < values[smalloc]) smalloc = j;
                //swap with that place
                Swap(values, i, smalloc);
            }
            return values;
        }

        //Swap elements of an array
        public static int[] Swap(int[] values, int a, int b)
        {
            if (a == b) return values;//For efficiency
            if(a < values.Length && b < values.Length)
            {
                int temp = values[a];
                values[a] = values[b];
                values[b] = temp;
            }
            return values;
        }


        public static Node InsertionSort(Node head)
        {
            return head;
        }

        public static void PrintArray(int[] values)
        {
            foreach (int i in values)
                Console.Write(i + " ");
            Console.WriteLine();
        }

        public static void PrintList(Node head)
        {
            if (head != null)
            {
                Console.Write(head.Value + " ");
                PrintList(head.Next);
            }
            else Console.WriteLine();
        }

        public static bool isSorted(int[] values)
        {
            for (int i = 0; i < values.Length - 1; ++i)
                if (values[i] > values[i + 1]) return false;
            return true;
        }
    }
}
