using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_4___Fun_with_Vectors
{
    
    class Program
    {
        public static Random rand = new Random();

        static void Main(string[] args)
        {
            List<int> ints; //Currently null!  This is just a reference that doesn't point to anything.
            ints = new List<int>(10); //Now it points to something!, But those somethings are empty.  10 of them

            Console.WriteLine("Capacity is: " + ints.Capacity);
            for (int i = 0; i < 10; ++i)
                ints.Add((rand.Next(100)));

            Console.WriteLine("Capacity is: " + ints.Capacity +" after 10 inserts.");
            ints.Add(rand.Next(100));
            Console.WriteLine("Capacity is: " + ints.Capacity + " after 11 inserts.");

            foreach (int i in ints)
                Console.WriteLine("You can foreach!" + i);

            int[] intsFromBeyond = ints.ToArray();

            foreach (int i in intsFromBeyond)
                Console.WriteLine("And generate arrays!" + i);

            ints.Sort();
            foreach (int i in ints)
                Console.WriteLine("And sort!" + i);

            ints.Insert(5, -1);
            foreach (int i in ints)
                Console.WriteLine("And insert!" + i);

            ints.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 });
            foreach (int i in ints)
                Console.WriteLine("And add arrays!" + i);

            for (int i = 0; i < ints.Count; ++i )
                Console.WriteLine("And use square brackets!" + ints[i]);

            if (ints.Contains(-1))
                Console.WriteLine("-1 present at index " + ints.IndexOf(-1));

            if (!ints.Contains(100000))
                Console.WriteLine("But no big round numbers.");


                Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
