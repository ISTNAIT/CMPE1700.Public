using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_11___Towers_of_Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            int Disks = 5; //This is what you got from the user.
            int StepCount = 1; //This is a shared variable that we will use
            Hanoi(Disks, "the first post", "the last post", "the middle post", ref StepCount);
            Console.ReadKey();
        }

        //Here is my recursive function
        static void Hanoi(int Disks, string From, string To, string Spare, ref int StepCount)
        {
            if(Disks > 0)
            {
                //Move top N-1 disks from starting point (From) to unused (Spare)
                //Using final destination (To) as my temporary spare.
                Hanoi(Disks - 1, From, Spare, To, ref StepCount); //NOTE ORDER CHANGE!
                
                //Move bottom disk (all that's left) to final destination
                Console.WriteLine("(" + (StepCount++) + ") Move disk " + Disks + " from " + From
                    + " to " + To);

                //Now, move the stack on the spare to my destination. But this time
                //we're using the now empty first disk (FROM) as our spare.
                Hanoi(Disks - 1, Spare, To, From, ref StepCount); //NOTE ORDER!
            }
        }
    }
}
