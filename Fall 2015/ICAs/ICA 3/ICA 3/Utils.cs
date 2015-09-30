using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA_3
{
    public class Utils
    {
        //General print error message
        public static void PrintError(string Err = "Unknown Failure", string Dbg = "",
                                    bool printUsage = true, bool exit = false, int exitVal = 1)
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
        public static void PrintUsage()
        {
            Console.WriteLine("Usage: " + System.AppDomain.CurrentDomain.FriendlyName + " <val>" +
                   @"where <val> is a \npositive integer greater than zero of no more than 64 bits.
                    Prints even or odd depending on bit parity of argument.");
        }
    }
}
