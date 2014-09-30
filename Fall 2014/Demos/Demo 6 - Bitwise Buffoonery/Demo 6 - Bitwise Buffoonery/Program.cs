using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Demo_6___Bitwise_Buffoonery
{
    class Program
    {
        enum BitFlags //Flags that correspond to exactly one bit set
        {
            Tall = 1,  //0001
            Wealthy = 2, //0010
            Handsome = 4, //0100
            Witty = 8, //1000
            Charming = 16,
            HasGuitar = 32
        }

        static void Main(string[] args)
        {
            //First, some reminders about i/o
            UInt64 val = 0xDEADBEEF;
            UInt64 val2 = 0xDEADBEEF;
            UInt64 val3 = 0xDEADBEEF;
            UInt64 val4 = 0u;
            Console.WriteLine("My value in decimal: {0} and hex: {0:x} \nand with all bits, upper: {0:X16}", val);

            Console.Write("Give me a hex number:");
            string sval = Console.ReadLine();
            try
            {
                val4 = UInt64.Parse(sval, NumberStyles.HexNumber);
            }
            catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
            Console.WriteLine("You typed: 0x{0:X}", val4);
        
            //Let's see the third (from least significant) byte:
            byte by = (byte)((val >>= 16) & (0xFF));
            Console.WriteLine("The third (from right) byte is: {0:X}", by);
            
            //Let's see the third (from least significant) byte (a different way)
            byte by2 = (byte)((val2 &= 0xFF0000)>>16);
            Console.WriteLine("The third (from right) byte is: {0:X}", by2);

            //Let's toggle the bits in the rightmost nibble
            val3 ^= 0xF;
            Console.WriteLine("Toggled LSNibble: {0:X}", val3);

            //Retoggle every second bit in that nibble
            val3 ^= 0x0A;
            Console.WriteLine("Retoggled Alternate in LSNibble: {0:X}", val3);

            //Retoggle the rest
            val3 ^= 0x05;
            Console.WriteLine("Retoggled Other Alternate in LSNibble: {0:X}", val3);

            //Set all the high order bits
            val3 |= 0xFFFFFFFF00000000;
            Console.WriteLine("Set high order bits: {0:X}", val3);

            //Clear every second nibble
            UInt64 Mask = ~0xF0F0F0F000000000u;
            val3 &= Mask;
            Console.WriteLine("Clear every second high order nibble: {0:X}", val3);
            
            //Playing with bitflags

            int ThatDude =  (int)(BitFlags.Tall | BitFlags.HasGuitar | BitFlags.Handsome);

            if ((ThatDude & (int)BitFlags.Wealthy) != 0)
                Console.WriteLine("That dude is wealthy.");
            else
                Console.WriteLine("Dirt poor.  But salt of the earth."); 
            
            if ((ThatDude & (int)BitFlags.Tall) != 0)
                Console.WriteLine("That dude is Tall.  Kind of a Jeff Goldblum vibe.");
            else
                Console.WriteLine("Maybe I can put a beer on his head.");


            Console.Write("Press any key to continue:");
            Console.ReadKey();

        }
    }
}
