using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Demo_5
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 65; ++i)
                Console.WriteLine("{0} -> {1}", i, AverageRuns(i));

            if (Debugger.IsAttached)
                Console.ReadKey();
        }

        //Average Number of Runs
        static public double AverageRuns(int bits)
        {
            //1<<bits is just 2^bits, the number of discrete
            //values with 8 bits.  
            long numvalues = 1L << bits;
            long totalruns = 0;
            //Get total runs from 0 to 2^n-1
            for (long val = 0;  val < numvalues; ++val)
            {
                totalruns += Runs(val);
            }
            return (double)totalruns/numvalues;
        }


        //Number of runs
        static public long Runs(long val)
        {
            bool running = false;
            long runs = 0;
            for(int i = 0; i < sizeof(long)*8; ++i)
            {
                //State machine for counting 0->1 transitions
                if(GetBit(val,i)) //bit is a 1
                {
                    if(running)
                    {
                        //do nothing
                    }
                    else
                    {
                        running = true;
                        runs++;
                    }
                }
                else //bit was a 0
                {
                    if (running)
                    {
                        running = false;
                    }
                    else
                    {
                        //do nothing
                    }
                }
            }
            return runs;
        }

        //True iff bit n of val == 1 (bit 0 is lsb)
        static public bool GetBit(long val, int n)
        {
            return (val & (1 << n)) != 0;
        }
    }
}
