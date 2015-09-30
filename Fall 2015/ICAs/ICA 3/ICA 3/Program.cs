using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong val = 0;  //Value I am generating prime factors for.

            //Confirm I have one argument (exactly)
            if (args.Count() != 1)
            {
                //Print error and exit
                Utils.PrintError("Invalid number of arguments (" + args.Count() + ")", "", true, true, -1);
            }

            //Confirm that it is a positive integer
            try
            {
                val = ulong.Parse(args[0]);
            }
            catch (Exception e)
            {
                Utils.PrintError("Parsing Error on argument \"" + args[0] + "\"", e.Message, true, true, -2);
            }

            //If I get here, I have a valid number to check parity of.

            Console.WriteLine((CountSetBits(val) % 2 == 1) ? "Odd":"Even");

        }

        static bool setP (ulong val, byte bit)
        {
            return (val & (1ul << bit)) != 0;
        }

        static byte CountSetBits(ulong val)
        {
            byte retVal = 0;
            for (byte i = 0; i < 64; ++i)
                if (setP(val, i)) ++retVal;
            return retVal;
        }
    }
}
