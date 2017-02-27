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
            Vector v = Vector.Initialize();
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
