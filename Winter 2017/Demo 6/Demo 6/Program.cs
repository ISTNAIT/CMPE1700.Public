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
            try
            {
                Vector.Add(v, 10);
            }
            catch (NullReferenceException nre)
            {
                Console.Error.WriteLine("Dude.  You need to initialize your vector.");
                v = Vector.Initialize();
                Vector.Add(v, 10);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Something awful happened: "
                    + ex.Message);
                if (Debugger.IsAttached) Console.ReadKey();
                Environment.Exit(-1);
            }

            v = Vector.Delete(v, 0);
            try
            { v = Vector.Delete(v, 0); }
            catch
            { Console.Error.WriteLine("Caught delete from empty exception."); }

            v = Vector.Insert(v, 0, 0);
            v = Vector.Delete(v, 0);
            try
            { v = Vector.Insert(v, 0, 10); }
            catch
            { Console.Error.WriteLine("Caught insert past end exception."); }

            for (int i = 0; i < 100; ++i)
            {
                v = Vector.Add(v, i);
            }

            try
            { v = Vector.Insert(v, 0, -1); }
            catch
            { Console.Error.WriteLine("Caught insert to negative exception."); }

            try
            { v = Vector.Delete(v,-1); }
            catch
            { Console.Error.WriteLine("Caught delete negative exception."); }

            try
            { v = Vector.Insert(v, 0, 1000); }
            catch
            { Console.Error.WriteLine("Caught insert out of range exception."); }

            try
            { v = Vector.Delete(v, 1000); }
            catch
            { Console.Error.WriteLine("Caught delete out of range exception."); }

            foreach (int i in v.Store)
                Console.Write(i + " ");

            Console.WriteLine(); for (int i = 0; i < 50; i += 2)
            {
                v = Vector.Delete(v, i);
            }

            foreach (int i in v.Store)
                Console.Write(i + " ");
            Console.WriteLine();

            Console.WriteLine(); for (int i = 0; i < 20; i += 2)
            {
                v = Vector.Insert(v, 42, i);
            }

            foreach (int i in v.Store)
                Console.Write(i + " ");
            Console.WriteLine();


            if (Debugger.IsAttached) Console.ReadKey();
        }
    }
}
