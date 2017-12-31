using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Demo_1
{
    /// <summary>
    /// Demo of some basic bit reading/manipulating techniques.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Read a bit.
            //Mask for reading has 1's in the bits I want to keep.
            //To read bit 6 of a number, I mean the bit for 2^6 (64).
            //Mask could just be "64".  But more portable to use <<
            uint rMask = 1 << 6;
            //And will keep the state of bits with a 1 in mask, set all others to 0
            Console.WriteLine("State of bit 6 for values from 0 to 255");
            for (int i = 0; i < 256; ++i)
            {
                //Detect state of bit 6
                bool bSet = (i & rMask) != 0;  //It wil be either 0 or 2^6
                Console.Write(bSet ? "T " : "F ");
            }
            Console.WriteLine();

            //How about reading bytes?
            //Same thing, we just mask with eight 1's (0xFF is eight ones).
            //Let's read byte 2 (the lsb is byte 0)

            rMask = 0xFF << (2 * 8); // <---left shift two bytes.
            Console.WriteLine("State of byte 3 for a bunch of values, stepped by 300000000:");
            for (uint i = 0x00A10000; (i > 0x00A00000) && (i < 0xFFFFFFFF) ; i+=3000000)
            {
                //Detect state of bit 6
                //In this case, I want to move my byte back to the right, so I 
                //don't have 4 trailing 0's
                Console.Write("0x{0:X} ", (i & rMask) >> (2 * 8));
            }

            //Set a bit.  
            //Same mask, just a one for the bit(s) I want to set, but use | (sometimes actually |=)
            //because 0|1 and 1|1 both go to 1, but x|0 stays at x.  So bits with 1 in the mask
            //will become 1, bits with 0 in the mask stay at whatever they are

            //Set bit 0 for all the numbers from 0 to 255:
            Console.WriteLine("Set bit 0 for values from 0 to 255");
            uint sMask = 1 << 0; //Which is really just "1", but it shows you why bit 0
            for (uint i = 0; i < 256; ++i)
            {
                Console.Write((i | sMask).ToString() + " ");
            }

            //Set alternate bit numbers from 0 to 255:
            Console.WriteLine("Set alternate bits values from 0 to 255"); 
            sMask = 0xAA; //Which is really just "1", but it shows you why bit 0
            for (uint i = 0; i < 256; ++i)
            {
                Console.Write("{0:X} ",(i | sMask));
            }

            //Clear a bit
            //In this case, the mask has a 0 where I want to clear and a 1 where I want 
            //to leave it the same.  (Bass-ackward read, basically).
            //1 & x is just x.  0 & x is always 0.

            //Clear bit 0 for all the numbers from 0 to 255:
            Console.WriteLine("Set bit 0 for values from 0 to 255");
            uint cMask = ~(1u << 0); //"1" is an int, complement made it negative.  "1u" is unsigned int.
            //(uint) 1 also works.  Note that ~() is waaay easier than 0xFFFFFFFE 
            for (uint i = 0; i < 256; ++i)
            {
                Console.Write((i & cMask).ToString() + " ");
            }

            //Clear alternate bit numbers from 0 to 255:
            Console.WriteLine("Set alternate bits values from 0 to 255");
            cMask = ~0xAAu; // or, like 0x55, which is the same, but let's be pedantic.
            for (uint i = 0; i < 256; ++i)
            {
                Console.Write("{0:X} ", (i & cMask));
            }

            //Toggle is the job of our friend XOR !!
            //Regular mask,  0 is leave it alone, 1 is toggle it.
            //Why?  0^x is just x (0^1->1, 0^0->0), but 1^x is ~x (1^1 -> 0,  1^0 -> 1)

            //Toggle bit 0 for all the numbers from 0 to 255:
            Console.WriteLine("Toggle bit 0 for values from 0 to 255");
            uint tMask = 1u << 0; 
            for (uint i = 0; i < 256; ++i)
            {
                Console.Write((i ^ tMask).ToString() + " ");
            }

            //Toggle alternate bit numbers from 0 to 255:
            Console.WriteLine("Toggle alternate bits values from 0 to 255");
            cMask = 0xAAu; // or, like 0x55, which is the same, but let's be pedantic.
            for (uint i = 0; i < 256; ++i)
            {
                Console.Write("{0:X} ", (i ^ tMask));
            }
            if (Debugger.IsAttached)
                Console.ReadKey();

        }
    }
}
