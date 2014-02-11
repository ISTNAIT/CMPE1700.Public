using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefOut
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 42;
            int j;
            Console.WriteLine("Foo returns " + foo(i));
            Console.WriteLine("Value of i is " + i);
            Console.WriteLine("Bar returns " + bar(ref i));
            Console.WriteLine("Value of i is " + i);
            Console.WriteLine("Quux returns " + quux(out j));
            Console.WriteLine("Value of j is " + j);

            Console.ReadLine();
        }

        static int foo(int i)
        {
            ++i;
            return i;
        }


        static int bar(ref int i)
        {
            ++i;
            return i;
        }

        static int quux(out int j)
        {
            j = 15;
            return 1;
        }

    }
}
