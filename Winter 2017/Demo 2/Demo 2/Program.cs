using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Demo_2
{
    class Program
    {
        public struct Thingee
        {
            public int i;
            public int[] a;
            public override string ToString()
            {
                return "i:" + i + " a[0]:" +a[0];
            }
        }

        public class Thingarama
        {
            public int i;
            public int[] a;
            public override string ToString()
            {
                return "i:" + i + " a[0]:" + a[0];
            }
        }

        static void Main(string[] args)
        {
            //Investigating value vs. reference

            int i = 0;
            int[] a = new int[1];
            a[0] = 0;

            Foo(i, a);
            Console.WriteLine("i:{0} a[0]:{1}", i, a[0]);

            Thingee t = new Thingee();
            t.i = 42;
            t.a = new int[1];
            t.a[0] = 5;

            Thingee s = t;
            s.i++;
            s.a[0]++;
            Console.WriteLine(t);
            Console.WriteLine(s);

            Thingarama tt = new Thingarama();
            tt.i = 42;
            tt.a = new int[1];
            tt.a[0] = 5;

            Thingarama ss = tt;
            ss.i++;
            ss.a[0]++;
            Console.WriteLine(tt);
            Console.WriteLine(ss);

            Thingarama rr = new Thingarama();
            rr.i = 43;
            rr.a = new int[1];
            rr.a[0] = 6;
            Console.WriteLine(rr);

            Console.WriteLine(ss == tt);
            Console.WriteLine(ss == rr);


            if (Debugger.IsAttached)
                Console.ReadKey();
        }

        public static void Foo (int i, int[] a)
        {
            i++;
            a[0]++;
        }
    }
}
