using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Demo_3___Recursion
{
    class Program
    {
        static void Main(string[] args)
        {

            PrintReverse("The answer is 42.");
            Console.WriteLine();
            PrintMirror("The answer is 42.");
            string p0 = "Kayak";
            string p1 = "Able was I, ere I saw Elba";
            string p2 = "I wish I were a Cabbage.";
            Console.WriteLine();

            Console.WriteLine(p1 + "-->" + new string(CleanString(p1)));

            Console.WriteLine(p0 + " " + WrapPal(p0));
            Console.WriteLine(p1 + " " + WrapPal(p1));
            Console.WriteLine(p2 + " " + WrapPal(p2));


            for (uint i = 0; i < 100; ++i) Console.Write(fibi(i) + " ");
            Console.WriteLine();
            for (uint i = 0; i < 100; ++i) Console.Write(fib(i) + " ");

            if (Debugger.IsAttached)
            {
                Console.WriteLine();
                Console.Write("-------------------\n"
                    +"Press Enter to Exit\n"
                    +"-------------------");
                Console.ReadLine();
            }
      
        }

        static uint fib(uint n)
        {
            if (n < 2) return 1;
            return fib(n - 1) + fib(n - 2);
        }

        static bool WrapPal(string s)
        {
            string p = new string(CleanString(s));
            return Palindrome(p, 0, p.Length - 1);
        }

        static bool Palindrome(string s,int first, int last)
        {
            if (s.Length < 2 || last - first < 2) return true;
            return (s[first] == s[last] && Palindrome(s, first + 1, last - 1));
        }

        static void PrintReverse(string s, int n=0)
        {
            if (n < (s.Length - 1)) PrintReverse(s, n + 1);
            Console.Write(s[n]);
        }

        static void PrintMirror(string s, int n = 0)
        {
            Console.Write(s[n]);
            if (n < (s.Length - 1)) PrintMirror(s, n + 1);
            Console.Write(s[n]);
        }

        //converts a string to a char[] with only lower case letters
        static char[] CleanString(string s)
        {
            List<char> l = new List<char>();
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                    l.Add(char.ToLower(c));
            }
            //l.Add((char)0); //Add null to terminate string
            return l.ToArray();
        }

        //Iterative Fibonacci
        static uint fibi(uint n)
        {
            uint f2 = 1; //f(n-2) (starting value for fib(0))
            uint f1 = 1; //f(n-1) (starting value for fib(1))
            uint f0 = 0; //f(n) --- the value of interest

            if (n < 2) return 1;
            for (int i = 2; i <= n; ++i)
            {
                f0 = f1 + f2; //Calculate current
                //Set up next iteration
                f2 = f1; //new n-2 is old n-1
                f1 = f0; //new n-1 is current n
            }
            return f0;
        }


    }
}
