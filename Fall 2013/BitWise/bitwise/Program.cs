using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace bitwise
{
    class Program
    {
        static void Main(string[] args)
        {
            byte b = 0 ;
            Console.WriteLine("Gimme a binary value: ");
            try
            {
                b = Convert.ToByte(Console.ReadLine(), 2);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("I said binary! (" + e.Message + ")");
            }

            Console.WriteLine("Your value with bit 4 set, 6 cleared and 2 toggled is: ");
            string output = Convert.ToString(ToggleBit(ClearBit(SetBit(b,4),6),2),2);
            int count = 8 - output.Length;
            for (int i = 0; i < count; ++i) //How many zeroes to pad?
                Console.Write('0');
            Console.WriteLine(output);

            Console.Write("'t' xored with 'k' is:");
            int v = 't' ^ 'k';
            Console.WriteLine(v);
            Console.Write(" xored with 'k' again is:");
            int w = v ^ 'k';
            Console.WriteLine(w);
            Console.Write("Cast back to char, it is:");
            Console.WriteLine((char)w);

        }

        static public byte SetBit(byte value, int digit)
        {
            //Use or with 1
            byte mask = (byte) (1 << digit);
            return (byte) (value | mask);
        }

        static public byte ClearBit(byte value, int digit)
        {
            //Use and with 0
            byte mask =(byte)~(1 << digit);
            return (byte)(value & mask);
        }

        static public byte ToggleBit(byte value, int digit)
        {
            //Use or with 1
            byte mask = (byte)(1 << digit);
            return (byte)(value ^ mask);
        }

    }
}
