using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RawList
{
    class Program
    {
        static void Main(string[] args)
        {
            Node head = null; //Empty List
            string data = null;

            //Populate my list
            do {
                Console.Write("Enter a string: ");
                data = Console.ReadLine();
                //Add data to list at end of list
                if (!string.IsNullOrEmpty(data))
                {
                    //Create my node
                    var temp = new Node(data); //Used for creating a new node
                    //Find last node
                    if (head == null)//List is empty
                    {
                        head = temp;
                    }
                    else
                    {
                        var current = head; //Reference to node that is currently of interest
                        while (current.Next != null) //If there is a next item
                            current = current.Next;//go to it.
                        //Now, insert after current (which should be the last item)
                        current.Next = temp;
                    }
                }
            }
            while (!string.IsNullOrEmpty(data));
            PrintList(head);
        }

        static public void PrintList(Node head)
        {
            if (head == null) return;
            Console.WriteLine(head.Value);
            PrintList(head.Next);
        }
    }
}
