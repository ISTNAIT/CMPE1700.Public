using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_5
{
    class Program
    {
        //Demonstration program to play with some single-descendant graph data structures
        //(Lists, Stacks,Queues)
        static void Main(string[] args)
        {
            Node myList = null;
            for (int i = 0; i < 10; ++i)
                myList = List.Add(myList, i.ToString(), i);

            List.PrintForward(myList);
            List.PrintBackward(List.GetTail(myList));

            Node myOtherList = null;
            myOtherList = List.InsertAlphabetical(myOtherList, "Larry");
            myOtherList = List.InsertAlphabetical(myOtherList, "Joe");
            myOtherList = List.InsertAlphabetical(myOtherList, "Moe");
            myOtherList = List.InsertAlphabetical(myOtherList, "Killer");
            myOtherList = List.InsertAlphabetical(myOtherList, "Lester");
            myOtherList = List.InsertAlphabetical(myOtherList, "Alpha");
            myOtherList = List.InsertAlphabetical(myOtherList, "Zulu");

            List.PrintForward(myOtherList);

            Node myStack = null;
            myStack = Stack.Push(myStack,"A");
            myStack = Stack.Push(myStack, "B");
            myStack = Stack.Push(myStack, "C");
            myStack = Stack.Push(myStack, "D");

            while(myStack != null)
            {
                string s;
                Console.Write(Stack.Peek(myStack) + " ");
                myStack = Stack.Pop(myStack, out s);
                Console.WriteLine(s);
            }
            Console.WriteLine();
            Node myQueue = null;
            myQueue = Queue.Enqueue(myQueue, "A");
            myQueue = Queue.Enqueue(myQueue, "B");
            myQueue = Queue.Enqueue(myQueue, "C");
            myQueue = Queue.Enqueue(myQueue, "D");

            while (myQueue != null)
            {
                string s;
                Console.Write(Queue.Peek(myQueue) + " ");
                myQueue = Queue.Dequeue(myQueue, out s);
                Console.WriteLine(s);
            }

            Console.ReadKey();

        }
    }
}
