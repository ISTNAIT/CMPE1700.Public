using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_7___Console_Exception_Handling
{
    class Program
    {
        public static void Main(string[] args)
        {
            uint arg;

            if (args.Length < 1)
            {
                Console.Error.WriteLine("Error: Insufficient Arguments");
                Console.Error.WriteLine("Usage: " + System.AppDomain.CurrentDomain.FriendlyName
                + " <number>");
                Environment.Exit(-1); //Not enough args
            }
            try
            {
                arg = uint.Parse(args[0]);
                if (arg == 0)
                {
                    Console.Error.WriteLine("Error: Argument must coercable into a natural number.");
                    Console.Error.WriteLine("Usage: " + System.AppDomain.CurrentDomain.FriendlyName
                    + " <number>");
                    Environment.Exit(-2); //Not a uint > 0
                }
            }
            catch(Exception e)
            {
                //Couldn't parse
                Console.Error.WriteLine("Error: Unable to parse input (" + e.Message + ")");
                Console.Error.WriteLine("Parsing 42 instead, because it is my favourite number.");
                arg = 42;
            }

            //If I made it here, I have a natural number to play with.
            try
            {
                Factor(arg);
            }
            catch (DivideByZeroException)
            {
                throw (new DivideByZeroException("Oh my God, they killed Kenny! Those bastards."));
            }
            catch (OverflowException e)
            {
                Console.Error.WriteLine("Error: Overflow.  Message was \"" + e.Message + "\"");
                Environment.Exit(-3); //Help me, 'm broke.
            }
            catch (ArgumentOutOfRangeException a)
            {
                Console.Error.WriteLine("Error: Factoring method declining to act.  Message was \"" + a.Message + "\"");
                Environment.Exit(-5); //Factorial is being bitchy.
            }
            catch
            {
                Console.Error.WriteLine("Error: Not sure.  Satan?");
                Environment.Exit(-4); //Help me, 'm broke.
                //throw;
            }
        }

        public static void Factor(uint value)
        {
            //Prints the prime factors of value to stdout
            //Uses recursion: Base Case is prime number (itself is only factor)
            //Iterative case is find the smallest factor, print it, then call factor on remainder

            if (value == 42)
            {
                throw new ArgumentOutOfRangeException("You sent me 42.  Stop doing that.  Just end the program. Sheesh.");
            }

            bool pprime = true; //If I found a factor, it isn't prime.  Assume prime for now.
            //int zero = 0;
            //int x = 5 / zero;

            //This loop takes advantage of the fact that, if a number has a factor, the factor's value
            //will be less than half of the original value (the smallest possible factor is 2,
            //and its co-factor is equal to value/2.)  If there is any factor, the smallest must lie between 2
            //and value/2.  We round up for obvious reasons.  By the Fundamental Theorem of Arithmetic, one 
            //isn't prime (or we would have infinite prime factors), so we exclude 1 by starting from 2.

            for (uint testValue = 2; testValue <= value / 2; ++testValue)
            {
                if (value % testValue == 0)
                { //If testValue is a factor
                    pprime = false;
                    Console.Write(testValue + " "); //Print factor
                    Factor(value / testValue); //Now factor remainder
                    break; //When I come back, I can stop looping.  Already found a factor on this iteration
                }
            }

            if (pprime) //Base case
                Console.WriteLine(value);
        }
    }
}
