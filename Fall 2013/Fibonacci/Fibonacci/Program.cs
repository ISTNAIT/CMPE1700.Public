using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            uint arg;

            if (args.Count() < 1)
            {
                Console.Error.WriteLine("Error: Insufficient Arguments");
                Console.Error.WriteLine("Usage: " + System.AppDomain.CurrentDomain.FriendlyName
                                           + " <number>");
                Environment.Exit(-1); //Not enough args
            }
            if (!uint.TryParse(args[0],out arg))
            {
                Console.Error.WriteLine("Error: Argument must coercable into a whole number.");
                Console.Error.WriteLine("Usage: " + System.AppDomain.CurrentDomain.FriendlyName
                                           + " <number>");
                Environment.Exit(-2); //Not a uint
            }

            //If I made it here, I have an unsigned int to play with.
            try
            {
                arg = Fibonacci(arg);
                Console.WriteLine(arg);
                Environment.Exit((int)arg);
            }
            catch(Exception e)
            {
                Console.Error.WriteLine("Error: Probably overflow.  Message was \"" + e.Message + "\"");
                Environment.Exit(-3); //Help me, 'm broke.
            }
            
        }

        static uint Fibonacci(uint arg) //Absurdly inefficient, but very pretty recursive version
        {
            switch (arg)
            {
                case 0 : case 1 :
                    return 1;
                default:
                    return Fibonacci(arg - 1) + Fibonacci(arg - 2);
            }
        }

        static uint FibIter(uint arg) //Iterative version of above (muuuuuch more efficient)
        {
            uint fibnminus1 = 1;
            uint fibnminus2 = 1;
            uint current = 0;
            if (arg < 2) return 1;

            for (int i = 1; i < arg; ++i)
            {
                current = fibnminus1 + fibnminus2;
                fibnminus2 = fibnminus1;
                fibnminus1 = current;
            }

            return current;
        }
    }
}
