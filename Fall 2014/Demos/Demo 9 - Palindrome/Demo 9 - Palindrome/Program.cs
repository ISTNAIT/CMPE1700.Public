using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Demo_9___Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            //if (args.Length < 1) Environment.Exit(-1);
            if (Palindrome(Flatten("akayaka")))
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
            Console.ReadKey();
        }

        //Remove whitespace and convert to lowercase.
        static string Flatten(string s)
        {
            if (s == null)
                return ""; //If I got nothing, return empty
            //Convert to lower case, and anything matching 
            //a 'whitepace' regular expression gets changed 
            //to ""
            return Regex.Replace(s.ToLower(), @"s", "" );
        }

        //True if a palindrome.
        static bool Palindrome(string s)
        {
            //Base case
            if (s.Length < 2)
                return true;
            //Inductive (iterative case) - if the first and last are the same
            //and the rest is a palindrome
            return (s[0] == s.Last()
                && Palindrome(s.Substring(1, s.Length - 2)));
        }
    }
}
