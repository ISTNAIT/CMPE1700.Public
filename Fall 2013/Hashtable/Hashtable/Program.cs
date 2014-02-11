using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Hashtable
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Hashtable of size 10000 to look up student IDs by name.
            int[] studentIds = new int[10000];

            //Add an entry
            studentIds[Hash("AJ Armstrong")] = 456788;

            //Report that entry
            Console.WriteLine("The student ID for AJ Armstrong is " + studentIds[Hash("AJ Armstrong")] +
                " at table location " + Hash("AJ Armstrong"));

            //Add an entry
            studentIds[Hash("Bob Dobbs")] = 345677;

            //Report that entry
            Console.WriteLine("The student ID for Bob Dobbs is " + studentIds[Hash("Bob Dobbs")] +
                " at table location " + Hash("Bob Dobbs"));

            //Let's force a collision

            //Add an entry
            studentIds[Hash("Dsbbo Bbo")] = 999999;

            //Report that entry
            Console.WriteLine("The student ID for Bob Dobbs is " + studentIds[Hash("Bob Dobbs")] +
                " at table location " + Hash("Bob Dobbs") + "(ahhhhhh! Collision!)");
        }

        //Hash a name into an integer.  Bucketspace is the size of the hashtable.
        public static int Hash(string name, int salt = 0, int bucketspace = 10000)
        {
            //I'm just going to use the Random class here to
            //help avoid collisions. Seed it with the reduced sum of name
            Random rand = new Random(Reduce(name));
            //get the nth random number (where n is the salt)
            int val = rand.Next();
            for (int i = 0; i < salt; ++i)
                val = rand.Next();
            //Return the result mod bucketspace size
            return val % bucketspace;
        }

        public static int Reduce(string s)
        {
            //Returns the sum of all the characters in the string
            int sum = 0;
            foreach (char c in s)
                sum += c;
            return sum;
        }
    }
}
