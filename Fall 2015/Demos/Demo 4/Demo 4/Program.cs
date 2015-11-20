using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_4
{
    //Some stuff on reference vs. value types, intro to linked list (theory)
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new linked list, which is really just a 
            //link to the first item

            IntNode myLinkedList = null; //No initial item

            for (int i = 0; i < 1000; ++i)
            {
                myLinkedList = AddToHead(myLinkedList, i);
            }

            RecursivePrintList(myLinkedList);
            Console.ReadKey();
        }

        static public void IterativePrintList(IntNode head)
        {
            IntNode current = head; //The one I'm workign on.
            while(current != null ) //Null is the last item on any list.
            {
                Console.Write(current.value + " ");
                current = current.next;
            }
            Console.WriteLine();
        }

        static public void RecursivePrintList(IntNode head)
        {
            if(head == null)
            {
                Console.WriteLine();
            }

            Console.Write(head.value + " ");

            //Head of the remainder of the list is just the next one after this one.
            RecursivePrintList(head.next);

        }

        static public IntNode AddToHead(IntNode head, int val)
        {
            //Inserts a new node in front of the existing one, returns new head.

            //Create new node.
            IntNode newFirstorHeadNode = new IntNode();
            newFirstorHeadNode.value = val;

            if (head == null) // Empty list
            {
                //easy.  My linked list has one node, the one I just created.
                return newFirstorHeadNode;
            }

            //Otherwise
            //Point new one to old first one (which will now be second).
            newFirstorHeadNode.next = head;

            //Return my new first item:
            return newFirstorHeadNode;

        }

    }
}
