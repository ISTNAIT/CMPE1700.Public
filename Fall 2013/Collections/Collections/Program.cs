using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collections
{
    public struct Student
    {
        public string Name;
        public uint ID;

        public Student(string name, uint id)
        {
            Name = name;
            ID = id;
        }

        public override string ToString()
        {
            return Name + " (" + ID + ")";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> s = new Stack<int>();
            Queue<int> q = new Queue<int>();

            for (int i = 0; i < 10; ++i)
            {
                s.Push(i);
                q.Enqueue(i);
            }

            while (s.Count > 0)
                Console.WriteLine(s.Pop()); //Writes them out in reverse order (9-0). 'Cause FILO

            while (q.Count > 0)
                Console.WriteLine(q.Dequeue()); //Writes them in order (FIFO).
            //New list
            LinkedList<Student> TwoKay = new LinkedList<Student>();
            //New node with a new student
            LinkedListNode<Student> Current = new LinkedListNode<Student>(new Student("AJ", 123432)); 
            //Take that node and add it to my list.
            TwoKay.AddFirst(Current);
            //Add a student without creating a node first
            TwoKay.AddBefore(TwoKay.First, new Student("Caleb", 123456));
            //Show it
            PrintList(TwoKay);
            //Change AJ
            TwoKay.First.Next.Value = new Student("AJ the Mighty", 333);
            //Print the list again
            PrintList(TwoKay);
            //Now, note that the value of current changed, too, because reference.
            Console.WriteLine(Current.Value);
        }

        public static void PrintList(LinkedList<Student> list)
        {
            foreach (Student s in list)
                Console.WriteLine(s);
        }
    }
}
