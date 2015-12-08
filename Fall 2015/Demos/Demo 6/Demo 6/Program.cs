using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_6
{
    class Program
    {
        //Demo program to explore the .Net Generic Collections
        static void Main(string[] args)
        {
            ListStuff();
            LinkedListStuff();

            Stack<int> myStack = new Stack<int>();
            Queue<int> myQueue = new Queue<int>();

            Stack<Stack<Queue<List<int>>>> thingee = new Stack<Stack<Queue<List<int>>>>();
            Console.ReadKey();
        }

        public static void ListStuff()
        {
            //First of all, let's look at the Vector, which is
            //called a List for no good reason at all.
            List<int> bunchOInts = new List<int>();
            Console.WriteLine("List capacity: " + bunchOInts.Capacity);
            Console.WriteLine("List size: " + bunchOInts.Count);
            Console.Write("Contents: ");
            foreach (int i in bunchOInts) Console.Write(i + " ");
            Console.WriteLine();

            bunchOInts.Add(1);
            Console.WriteLine("List capacity: " + bunchOInts.Capacity);
            Console.WriteLine("List size: " + bunchOInts.Count);
            Console.Write("Contents: ");
            foreach (int i in bunchOInts) Console.Write(i + " ");
            Console.WriteLine();

            bunchOInts.Add(2);
            bunchOInts.Add(3);
            bunchOInts.Add(4);
            Console.WriteLine("List capacity: " + bunchOInts.Capacity);
            Console.WriteLine("List size: " + bunchOInts.Count);
            Console.Write("Contents: ");
            foreach (int i in bunchOInts) Console.Write(i + " ");
            Console.WriteLine();

            bunchOInts.Add(5);
            Console.WriteLine("List capacity: " + bunchOInts.Capacity);
            Console.WriteLine("List size: " + bunchOInts.Count);
            Console.Write("Contents: ");
            foreach (int i in bunchOInts) Console.Write(i + " ");
            Console.WriteLine();

            bunchOInts.RemoveAt(0);
            Console.WriteLine("List capacity: " + bunchOInts.Capacity);
            Console.WriteLine("List size: " + bunchOInts.Count);
            Console.Write("Contents: ");
            foreach (int i in bunchOInts) Console.Write(i + " ");
            Console.WriteLine();

            bunchOInts.Capacity = (bunchOInts.Count + 1);
            Console.WriteLine("List capacity: " + bunchOInts.Capacity);
            Console.WriteLine("List size: " + bunchOInts.Count);
            Console.Write("Contents: ");
            foreach (int i in bunchOInts) Console.Write(i + " ");
            Console.WriteLine();

            bunchOInts.Add(6);
            bunchOInts.Add(7);
            Console.WriteLine("List capacity: " + bunchOInts.Capacity);
            Console.WriteLine("List size: " + bunchOInts.Count);
            Console.Write("Contents: ");
            foreach (int i in bunchOInts) Console.Write(i + " ");
            Console.WriteLine();

            bunchOInts.Reverse();
            Console.Write("Reversed: ");
            foreach (int i in bunchOInts) Console.Write(i + " ");
            Console.WriteLine();

            bunchOInts.Sort();
            Console.Write("Sorted: ");
            foreach (int i in bunchOInts) Console.Write(i + " ");
            Console.WriteLine();

            Console.WriteLine("Value3 found at position: " + bunchOInts.IndexOf(3));

        }

        public static void LinkedListStuff()
        {
            //Linked list superclass

            LinkedList<int> listOInts = new LinkedList<int>();
            for(int i = 9; i >= 0; --i)
                listOInts.AddLast(i);

            listOInts.AddAfter(listOInts.First.Next.Next, 666);

            foreach (int i in listOInts)
                Console.Write(i + " ");
            Console.WriteLine();

            List<int> vector = new List<int>(listOInts);
            vector.Sort();


            foreach (int i in vector)
                Console.Write(i + " ");
            Console.WriteLine();

            PrintReverse(listOInts.First);
            Console.WriteLine();
            
          
       
        }

        public static void PrintReverse(LinkedListNode<int> head)
        {
            if (head.Next != null) PrintReverse(head.Next);
            Console.Write(head.Value);
        }
    }
}
