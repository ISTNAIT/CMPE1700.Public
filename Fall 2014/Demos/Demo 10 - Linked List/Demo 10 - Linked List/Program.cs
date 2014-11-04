using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_10___Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            //Need a reference to my list
            Node head = null;

            //Generate the list
            for(int i = 0; i < 100; ++i)
            {
                //Create a new random node and add it to the end of the list
                head = ListAddtoEnd(head, r.Next(100));
            }
            PrintList(head);
            Console.WriteLine();
            PrintListInReverse(head);
            Console.WriteLine();

            Console.ReadKey();
        }

        static public Node ListAddtoEnd(Node head, int val)
        {
            //Special case of empty list.
            if (head == null)
                return new Node(val);

            //Otherwise, need reference to last node
            Node tail = head;
            while (tail.next != null)
                tail = tail.next;
            tail.next = new Node(val);

            return head;
        }

        static public Node ListAddInOrder(Node head, int val)
        {
            //This is your ICA for next Monday.  Have fun!!!!

            //***Two special cases!  (1) Empty list, (2)  Insert at head

            //If I want to know the value of the node after my reference 
            //Current.Next.Value is the value of the node after Current.
            //Current.Next.Next.Value is the value of the node after that.  BEWARE OF NULLS!
            //If (Current.Next != Null) will be needed.
            return head;

        }

        static public void PrintList(Node head)
        {
            if (head != null)
            {
                Console.Write(head + " ");
                PrintList(head.next);
            }
        }

        static public void PrintListInReverse(Node head)
        {
            if (head != null)
            {
                PrintListInReverse(head.next);
                Console.Write(head + " ");
            }
        }
    }
}
