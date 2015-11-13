using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Demo_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            prefixAdd(5);
            Console.WriteLine();
            postfixAdd(5);
            Console.WriteLine();
            infixAdd(5);
            Console.WriteLine();
            Console.Write("Give me some words:");
            string sentence = Console.ReadLine();
            sentence = flatten(sentence);
            Console.WriteLine("Flattened: " + sentence);
            Console.WriteLine("This is " + (ispalindrome(sentence) ? "" : "not ") + "a palindrome");

            Console.ReadKey();
        }

        public static string flatten(string input)
        {
            string retval = input.ToLower();
            retval = Regex.Replace(retval, @"[ !.,;:]","");

            return retval;

        }

        static public bool ispalindrome(string s)
        {
            if (s.Length < 2) return true;
            if (s.First() == s.Last() && ispalindrome(s.Substring(1, s.Length - 2)))
                return true;
            return false;
        }

        static void prefixAdd(int i)
        {
            if (i < 0) return;
            Console.Write(i + " ");
            prefixAdd(i - 1);
        }

        static void postfixAdd(int i)
        {
            if (i < 0) return;
            postfixAdd(i - 1);
            Console.Write(i + " ");
        }

        static void infixAdd(int i)
        {
            if (i < 0) return;
            Console.Write(i + " ");
            infixAdd(i - 1);
            Console.Write(i + " ");
        }
    }
}
