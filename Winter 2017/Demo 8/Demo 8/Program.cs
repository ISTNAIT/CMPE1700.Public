using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Demo_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Node Head = null;
            for (int i = 0; i < 10; ++i)
                Head = AddToHead(Head, i);
            Console.WriteLine(ListToString(Head));

            for (int i = 0; i < 10; ++i)
                Head = AddToTail(Head, i);
            Console.WriteLine(ListToString(Head));

            Head = null; //throw away old list

            for (int i = 0; i < 100; ++i)
                Head = InsertInOrder(Head, r.Next(100));

            Console.WriteLine(ListToString(Head));

            PrintListInReverse(Head);

            if (Debugger.IsAttached)
                Console.ReadLine();

        }

        //Also recursive!!  And cool!

        static void PrintListInReverse(Node head)
        {
            if (head != null) PrintListInReverse(head.Next);
            Console.Write((head==null)?"\n":(head.Value + " "));
        }

        //Recursive!!!
        static string ListToString(Node Head)
        {
            while (Head != null)
                return Head.ToString() + " " + ListToString(Head.Next);
            return "";
        }

        static Node AddToHead(Node Head, int value)
        {
            //Must return a new node, because I need to point to a different head.
            //Create a new node
            Node newHead = new Node(value);
            newHead.Next = Head;
            return newHead;
        }

        static Node AddToTail(Node Head, int value)
        {
            //Create new node
            Node newNode = new Node(value);
            //Special case --- null list
            if (Head == null)
                return newNode;

            //Find last node in list
            Node current = Head;
            while (current.Next != null) //Condition of last node.
                current = current.Next;
            //Insert new node after current, which is last node
            current.Next = newNode;
        
            return Head;
        }

        static Node InsertInOrder(Node Head, int value)
        {
            //Create new node
            Node newNode = new Node(value);
            //Special case --- null list
            if (Head == null)
                return newNode;

            //Special case --- need to insert in front of current head
            if (Head.Value > value )
            {
                newNode.Next = Head;
                return newNode;
            }

            //Otherwise, find the node BEFORE the insertion point (must look ahead).
            Node current = Head;
            //While (1) Not at last node and (2) Node shouldn't be inserted in front of nec
            while (current.Next != null && current.Next.Value < value)
                current = current.Next;
            //Perform insert after current node
            newNode.Next = current.Next;
            current.Next = newNode;

            return Head;
        }
    }
}
