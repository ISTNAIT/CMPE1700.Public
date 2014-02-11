using System;

namespace Recurse
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			uint arg;

			if (args.Length < 1) {
				Console.Error.WriteLine ("Error: Insufficient Arguments");
				Console.Error.WriteLine ("Usage: " + System.AppDomain.CurrentDomain.FriendlyName
				+ " <number>");
				Environment.Exit (-1); //Not enough args
			}
			if (!uint.TryParse (args [0], out arg) || arg == 0) {
				Console.Error.WriteLine ("Error: Argument must coercable into a natural number.");
				Console.Error.WriteLine ("Usage: " + System.AppDomain.CurrentDomain.FriendlyName
				+ " <number>");
				Environment.Exit (-2); //Not a uint > 0
			}

			//If I made it here, I have a natural number to play with.
			try {
				Factor (arg);
			} catch (Exception e) {
				Console.Error.WriteLine ("Error: Probably overflow.  Message was \"" + e.Message + "\"");
				Environment.Exit (-3); //Help me, 'm broke.
			}	
		}

		public static void Factor (uint value)
		{
			//Prints the prime factors of value to stdout
			//Uses recursion: Base Case is prime number (itself is only factor)
			//Iterative case is find the smallest factor, print it, then call factor on remainder

			bool pprime = true; //If I found a factor, it isn't prime.  Assume prime for now.

			//This loop takes advantage of the fact that, if a number has a factor, the factor's value
			//will be less than half of the original value (the smallest possible factor is 2,
			//and its co-factor is equal to value/2.)  If there is any factor, the smallest must lie between 2
			//and value/2.  We round up for obvious reasons.  By the Fundamental Theorem of Arithmetic, one 
			//isn't prime (or we would have infinite prime factors), so we exclude 1 by starting from 2.

			for (uint testValue = 2; testValue <= value/2; ++testValue) {
				if (value % testValue == 0) { //If testValue is a factor
					pprime = false;
					Console.Write (testValue + " "); //Print factor
					Factor (value / testValue); //Now factor remainder
					break; //When I come back, I can stop looping.  Already found a factor on this iteration
				}
			}

			if (pprime) //Base case
				Console.WriteLine (value);
		}
	}
}
