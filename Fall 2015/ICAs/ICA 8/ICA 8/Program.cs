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
            int collSize = 10;
            

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
            InsertionSort(ref head);
            PrintList(head);
            Console.WriteLine("List is " + (isSorted(head) ? "sorted." : "not sorted."));

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

        //Sort a linked list
        public static Node InsertionSort(ref Node head)
        {
            //Head is the list I want to sort.
            //Sorted is the new list I will build with insertions.
            Node sorted = null;
            Node newhead = null;
            Node insertpoint = null;
            while (head != null)
            {
                //The node currently at head needs to be sorted in.
                //Find the location in sorted where I want this

                //Add to head of sorted?
                if(sorted == null || sorted.Value > head.Value)
                {
                    //add to head
                    newhead = head.Next;
                    head.Next = sorted; //Insert sorted list after head
                    //Clean up pointers
                    sorted = head;
                    head = newhead;
                }

                //Otherwise, find insertion point
                else
                {
                    insertpoint = sorted;
                    while (insertpoint.Next != null && insertpoint.Next.Value < head.Value)
                        insertpoint = insertpoint.Next;
                    //insertpoint now at node before where I want to sort
                    newhead = head.Next;
                    head.Next = insertpoint.Next;
                    insertpoint.Next = head;
                    //Clean up pointers
                    head = newhead;
                }
            }
            //head is null right now.
            head = sorted;
            return sorted;
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

        public static bool isSorted(Node head)
        {
            if (head == null) return true;
            if (head.Next == null) return true;
            return ((head.Next.Value >= head.Value) && isSorted(head.Next));
        }
    }
}
