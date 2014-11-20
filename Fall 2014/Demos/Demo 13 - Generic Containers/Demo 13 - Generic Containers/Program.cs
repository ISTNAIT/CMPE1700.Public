using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_13___Generic_Containers
{
    class Program
    {
        public enum EyeColor
        {
            Brown = 0,
            Blue,
            Green,
            Grey,
            Violet,
            Hazel,
            GlowingEvilRed
        }

        public struct Student
        {
            uint age;
            string name;
            uint studentid;

            public Student(uint id, string name, uint age)
            {
                studentid = id;
                this.name = name;
                this.age = age;
            }

            public override string ToString()
            {
                return name + "(" + age + ")";
            }

        }

        static void Main(string[] args)
        {
            Random r = new Random();
            List<int> listoints = new List<int>(10);

            //Populate my list with some random numbers.
            for(int i = 0; i < listoints.Capacity; ++i)
            {
                listoints.Add(r.Next(100));
            }

            //Sort em
            listoints.Sort();

            //Print them out
            foreach (int i in listoints)
                Console.Write(i + " ");
            Console.WriteLine();

            //Put into a stack
            Stack<int> stackoints = new Stack<int>();
            foreach (int i in listoints)
                stackoints.Push(i);

            //Print em out
            while (stackoints.Count > 0)
                Console.Write(stackoints.Pop() + " ");
            Console.WriteLine();

            //Put into a queue
            Queue<int> qoints = new Queue<int>();
            foreach (int i in listoints)
                qoints.Enqueue(i);

            //Print em out
            while (qoints.Count > 0)
                Console.Write(qoints.Dequeue() + " ");
            Console.WriteLine();

            //Linked Lists
            //Remember that there are two types: (1) LinkedList<> which is a wrapper for the list, 
            //(2)LinkedListNode<> which is like the other nodes we worked with (i.e. "next" member).

            LinkedList<int> llif = new LinkedList<int>();
            LinkedList<int> llib = new LinkedList<int>();

            foreach(int i in listoints)
            {
                llib.AddFirst(i); //Add to head of list (stack!)
                llif.AddLast(i); //Add to tail of list (queue!)
            }

            //Print it out with a travelling reference
            LinkedListNode<int> llnib = llib.First;
            while(llnib != null)
            {
                Console.Write(llnib.Value + " ");
                llnib = llnib.Next;
            }
            Console.WriteLine();

            LinkedListNode<int> llnif = llif.First;
            while (llnif != null)
            {
                Console.Write(llnif.Value + " ");
                llnif = llnif.Next;
            }
            Console.WriteLine();

        
            //Dictionaries, too!

            Dictionary<string, EyeColor> EyeColors = new Dictionary<string, EyeColor>();
            EyeColors.Add("AJ Armstrong", EyeColor.Brown);
            EyeColors.Add("Elizabeth Taylor", EyeColor.Violet);
            EyeColors.Add("Barack Obama", EyeColor.GlowingEvilRed);

            //As LinkedListNode is to LinkedList, KeyValuePair is to Dictionary
            foreach (KeyValuePair<string, EyeColor> kvp in EyeColors)
                Console.WriteLine("{0}, {1}", kvp.Key, kvp.Value);

            //Can also look things up
            Console.WriteLine(EyeColors["AJ Armstrong"]);

            //Can get more complex 
            //Dictionary of linked lists containing students of a particular age.

            Dictionary<uint, LinkedList<Student>> dull = new Dictionary<uint, LinkedList<Student>>();

            //Note duplicate ages
            AddToDictionary(dull, "AJ Armstrong", 165, 345433);
            AddToDictionary(dull, "Bob Dobbs", 165, 34433);
            AddToDictionary(dull, "Larry the Wonder Llama", 165, 3433);
            AddToDictionary(dull, "Stinky the Cat", 65, 34533);
            AddToDictionary(dull, "Joe Blow", 65, 345433);

            PrintForAge(dull,165);

            Console.ReadKey();
        }

        static public void AddToDictionary(Dictionary<uint, LinkedList<Student>> dull, string name, uint age, uint id)
        {
            //Is there already an entry with that key?
            if (!dull.ContainsKey(age)) //Need to create a new list
                dull.Add(age, new LinkedList<Student>());
            //Now that key was created, I should always be able to add to it.
            dull[age].AddLast(new Student(id, name, age));
        }

        static public void PrintForAge(Dictionary<uint, LinkedList<Student>> dull, uint age)
        {
            if (!dull.ContainsKey(age))
                Console.WriteLine("None Found");
            else
                foreach (Student s in dull[age])
                    Console.WriteLine(s);

        }

    }
}
