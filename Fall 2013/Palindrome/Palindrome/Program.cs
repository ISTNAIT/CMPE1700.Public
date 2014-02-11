using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() < 1)
            {
                Console.Error.WriteLine("Usage: " + System.AppDomain.CurrentDomain.FriendlyName
                                        + " <string>");
                Environment.Exit(-1);
            }

            //Get rid of non-alpha
            Regex rgx = new Regex("[^a-zA-Z]");
            string s = rgx.Replace(args[0], "");

            //All Lower case
            s = s.ToLowerInvariant();

            if (IsPalindrome(s))
            {
                Console.WriteLine("is a palindrome.");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("is not a palindrome.");
                Environment.Exit(1);
            }

        }

        static bool IsPalindrome(string s)
        {
            switch (s.Length)
            {
                case 0:
                    return true;
                case 1:
                    return true;
                default: //Return true if first and last match and remainder is a palindrome
                    return (s.First() == s.Last()) && IsPalindrome(s.Substring(1, s.Length - 2));
            }
        }

    }
}
