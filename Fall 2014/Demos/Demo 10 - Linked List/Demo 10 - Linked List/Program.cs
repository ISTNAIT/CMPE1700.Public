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
            for(int i = 0; i < 100000; ++i)
            {
                //Create a new random node and add it to the end of the list
               // head = ListAddtoEnd(head, r.Next(100));
                
                //Create a new random node and add it in order
                head = ListAddInOrder(head, r.Next(100));
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


            //THIS IS THE SOLUTION
            //Case 1 - Empty list
            if (head == null)
            {
                //Pretty easy
                Node newNode = new Node(val); //Pretty new node
                //Aaand that's my whole list, so just return it.
                return newNode; //This is the new reference to the head of the list.
            }

            //Case 2 -- Add in front of head of the list (another case where
            //          we need a new head)
            if(head.value > val)
            {
                Node newHead = new Node(val);
                newHead.next = head; //Connect to old head.
                return newHead;
            }

            //Case 3 -- Belongs somewhere else in the list
            //If I made it here, then that's the case. No need for an if.
            //Find my insertion point
            Node current = head; //Pointer to head
            while (current.next != null && current.next.value < val) //While my current is not pointing to insert point
                current = current.next;
            //Current must now point to my insertion point, so insert
            Node reallynewNode = new Node(val);
            reallynewNode.next = current.next;
            current.next = reallynewNode;
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
