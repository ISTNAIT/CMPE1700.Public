using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Texty
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sOut;
            StreamReader sIn;
            string FileName;
            string Buffer;
            int i;

            Console.Write("FileName? ");
            FileName = Console.ReadLine();

            try{
                sOut = new StreamWriter(FileName, true); // Open for appending
                Console.WriteLine("Start typing to add to your file.  Blank line to end.");
                do{
                    Buffer = Console.ReadLine();
                    sOut.WriteLine(Buffer);
                }
                while (Buffer.Length > 0);
                sOut.Close();
            }
            catch(Exception e)
            {
                Console.Error.Write("Unable to open file.  Error was " + e.Message);
            }

            Console.WriteLine("Current contents of file are: ");

            try
            {
                sIn = new StreamReader(FileName);
                while ((i = sIn.Read()) != -1)
                {
                    Console.Write((char)i);
                }
                sIn.Close();
            }
            catch (Exception e)
            {
                Console.Error.Write("Unable to open file.  Error was " + e.Message);
            }

        }
    }
}
