using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_1
{
    class Program
    {
        /*******************************************
        *
        * Accepts one argument which must be a positive integer > 0
        * Outputs space delimitted list of prime factors of arg 1
        *
        **********************************************/

        static void Main(string[] args)
        {
            uint val = 0;  //Value I am generating prime factors for.

            //Confirm I have one argument (exactly)
            if(args.Count() != 1)
            {
                //Print error and exit
                PrintError("Invalid number of arguments (" + args.Count() + ")", "", true, true, -1);
            }

            //Confirm that it is a positive integer
            try
            {
                val = uint.Parse(args[0]);
            }
            catch (Exception e)
            {
                PrintError("Parsing Error on argument \"" + args[0] + "\"", e.Message, true, true, -2);
            }

            if (val < 1)
            {
                PrintError("Zero is not a permitted input argument", "", true, true, -3);
            }

            //Generate factors (if possible)

            //If I got here, I got a positive integer, currently stored in val.
            Factor(val);
        }

        static void Factor (uint val) // Prints out factors
        {
            if (val == 1) return;
            for (int i = 2; i <= val / 2; ++i) //Potential factors.
            {
                //Is i a factor
                if (val % i == 0) // Found one!
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }

        //General print error message
        static void PrintError(string Err = "Unknown Failure", string Dbg = "",
                                    bool printUsage = true,  bool exit = false, int exitVal = 1)
        {

            //1 Print out error message
            ConsoleColor currBackColor = Console.BackgroundColor;
            ConsoleColor currForeColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine("Error: " + Err);
            if (Dbg.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Error.WriteLine(Dbg);
            }
            Console.ForegroundColor = currForeColor;
            Console.BackgroundColor = currBackColor;
            if (printUsage)
                PrintUsage();

            if (exit)
                Environment.Exit(exitVal); // By convention, exit with a value != 0 for error
        }

        //General usage message
        static void PrintUsage ()
        {
            Console.WriteLine("Usage: " + System.AppDomain.CurrentDomain.FriendlyName + " <val>" +
                   " where <val> is a \npositive integer greater than zero.  Prints \nspace-delimitted" +
                   " list of prime factors of only \nargument.");
        }
    }
}
