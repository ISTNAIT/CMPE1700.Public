using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Demo_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector v = new Vector();
            try {
                Vector.Add(v, 10);
            }
            catch(NullReferenceException nre)
            {
                Console.Error.WriteLine("Dude.  You need to initialize your vector.");
                v = Vector.Initialize();
                Vector.Add(v, 10);
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine("Something awful happened: " 
                    + ex.Message);
                if (Debugger.IsAttached) Console.ReadKey();
                Environment.Exit(-1);
            }

            for(int i = 0; i < 100; ++i)
            {
                v = Vector.Add(v, i);
            }

            foreach (int i in v.Store)
                Console.Write(i + " ");
            Console.WriteLine();

            if (Debugger.IsAttached) Console.ReadKey();
        }
    }
}
