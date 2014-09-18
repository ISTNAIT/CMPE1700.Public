using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_3___Iteration_with_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            //Training requirement.  I need to have a training flight between
            //every possible pair of aviators (that is, I want each pilot to fly
            //one flight with every other pilot).  How to do that?

            //ITERATE!

            //First, I need a array big enough to hold all the possibilities:
            int pilotCount = Enum.GetValues(typeof(Aviator)).Length;
            //Total number of combos is X^2-X or X(X-1), if we care about order
            //PairedFlight[] flights = new PairedFlight[pilotCount*pilotCount - pilotCount];
            //If we want to combo so they fly together only once (don't care about order)
            //(x-1) + (x-2) + (x-3) + .... + 1 =  x * (x-1)/2 
            PairedFlight[] flights = new PairedFlight[pilotCount * (pilotCount - 1) / 2]; 
            
            int i = 0;

            foreach (Aviator pilot in Enum.GetValues(typeof(Aviator)))
            {
                //Use below if you don't want them to fly together at ALL
                //Need to change your size of array, too
                for (Aviator firsto = pilot+1; firsto <= (Aviator)(pilotCount-1); firsto++)
                    //foreach (Aviator firsto in Enum.GetValues(typeof(Aviator))) //For everybody doubles up
                    {
                        if (pilot != firsto)
                            flights[i++] = new PairedFlight(pilot, firsto); //Woooo! Fancy postscript ++
                    }
            }

            foreach (PairedFlight flight in flights)
                Console.WriteLine(flight);

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
