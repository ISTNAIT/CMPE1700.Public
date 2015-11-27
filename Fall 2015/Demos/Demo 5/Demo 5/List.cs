using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_5
{
    public class List
    {
        //Utility functions for managing a Linked List
        //Not what MS thinks is a "List".  A real list, dammit.

        //Add a new node as the pos'th item.  0 means add to front,
        // -1 or a pos greater than the last item means add to end.
        public static Node Add(Node head, string value, int pos)
        {
            //Create my new Node.
            Node newNode = new Node();
            newNode.Value = value;

            //Am I adding to head?
            if (head == null || pos == 0)
            {
                newNode.Next = head;
                if (head != null) head.Previous = newNode;
                newNode.Previous = null;
                return newNode;
            }

            //Find the position I care about.
            int position = 0;
            Node current = head;
            while (current.Next != null && (position < pos - 1 || pos == -1))
            {
                position++;
                current = current.Next;
            }
            //At this point, I should be looking at either the last node,
            //Or the node before position pos.  Insert here.
            newNode.Next = current.Next;
            newNode.Previous = current;
            current.Next = newNode;
            return head;
        }

        //Print forward.  Recursive
        public static void PrintForward(Node head)
        {
            if (head == null) { Console.WriteLine(); return; }
            Console.Write(head.Value + " ");
            PrintForward(head.Next);
        }

        public static void PrintBackward(Node tail)
        {
            if (tail == null) { Console.WriteLine(); return; }
            Console.Write(tail.Value + " ");
            PrintBackward(tail.Previous);
        }

        public static Node GetTail(Node head)
        {
            //Recursive, cause it's fun
            if (head == null || head.Next == null) return head;
            return GetTail(head.Next);
        }

        public static Node InsertAlphabetical(Node head, string value)
        {
            //Insert at head?
            if (head == null || string.Compare(head.Value, value) == 1)
            {
                return Add(head, value, 0);
            }
            //Otherwise, find insertion point

            Node current = head;
            int pos = 1;
            while (current.Next != null && (string.Compare(current.Next.Value, value) < 1))
            {
                pos++;
                current = current.Next;
            }
            return Add(head, value, pos);

        }

    }
}
