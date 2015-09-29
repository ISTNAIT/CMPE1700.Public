using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_1
{
    public enum Adj
    {
        Tall = 1,
        Short = 2,
        Frisky = 4,
        Beige = 8,
        Annoying = 16,
        Thermonuclear = 32
    }

    //Project to demonstrate bitwise operations
    class Program
    {
        static void Main(string[] args)
        {
            for (ulong i = 0; i < 10; ++i)
                Console.WriteLine(i + " has bit 3" + (setP(i,3) ? " 3 sefdgadsfgat.":" cleared."));

            ulong val = 15;
            Console.Write("The value 15 becomes ");
            Set(ref val, 10);
            Console.Write(val + " when the 10th bit is set.");

            Console.Write(" But it goes back to ");
            Clear(ref val, 10);
            Console.Write(val + " when the 10th bit is cleared.");

            Console.Write(" And goes back to ");
            Toggle(ref val, 10);
            Console.Write(val + " when the 10th bit is toggled.");

            Console.Write(" And yet again goes back to ");
            Toggle(ref val, 10);
            Console.Write(val + " when the 10th bit is toggled once more.");
            Console.WriteLine();
            Console.WriteLine();

            //Create a new variable that will use bit positions to set and clear flags.

            ulong Thing = (ulong) (Adj.Annoying | Adj.Thermonuclear | Adj.Beige);

            //use base-2 log to get which bit corresponds to Thermonuclear
            if (setP (Thing, (byte) Math.Log((double)Adj.Thermonuclear,2)))
                Console.WriteLine("My thing is thermonuclear!");

            if (clearP (Thing, (byte) Math.Log((double) Adj.Frisky, 2)))
                Console.WriteLine("But not frisky!");

            Console.ReadKey();
        }

        //Return true if bit in question is set
        //value is the number to test, bit is the
        //bit position to test (0 = LSB, 63 = MSB)
        static bool setP (ulong value, byte bit )
        {
            ulong mask = 1ul << bit;
            ulong result = value & mask;
            return result != 0;
        }

        //Return tru if bit in question unset
        static bool clearP (ulong value, byte bit)
        {
            return !setP(value, bit);
        }

        //Set bit in question (uses ref so not just changing a copy).
        static ulong Set(ref ulong value, byte bit)
        {
            value = value | (1ul << bit);

            return value;
        } 
        
        //Clear bit in question (uses ref so not just changing a copy).
        static ulong Clear(ref ulong value, byte bit)
        {
            //Use an inverse mask
            value = value & ~(1ul << bit);

            return value;
        }

        //Toggle the bit in question
        static ulong Toggle(ref ulong value, byte bit)
        {
            value = value ^ (1ul << bit);
            return value;
        }

    }
}
