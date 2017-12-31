using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Demo_10
{
    class Program
    {
        static void Main(string[] args)
        {
            const int SetSize = 100;
            Random r = new Random();
            List<int> Set = new List<int>(SetSize);
            for (int i = 0; i < SetSize; ++i)
                Set.Add(r.Next(SetSize));

            PrintList(Set);
            Console.WriteLine("******");
            Set = MergeSort(Set);
            PrintList(Set);
            Console.WriteLine("******");
            if (pSorted(Set))
                Console.WriteLine("Woohoo!");

            if (Debugger.IsAttached) Console.ReadLine();

        }

        static bool pSorted(List<int> l)
        {
            for (int i = 0; i < l.Count - 1; ++i)
                if (l[i] > l[i + 1])
                    return false;
            return true;
        }

        static void PrintList(List<int> l)
        {
            foreach (int i in l)
                Console.Write(i + " ");
            Console.WriteLine();
        }

        //Destructive "copy" version.  In reality,
        //we would do an in-place version.  Stay tuned.
        static List<int> MergeSort(List<int> set)
        {
            //Base case
            int size = set.Count;
            if (size < 2) return set;

            //Other base case
            if (size == 2)
            {
                if (set[0] > set[1])
                {
                    int temp = set[0];
                    set[0] = set[1];
                    set[1] = temp;
                }
                return set;
            }

            int middle = set.Count / 2;
            return Merge(MergeSort(set.GetRange(0, middle)),
                MergeSort(set.GetRange(middle,set.Count-middle)));
        }

        static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> buffer = new List<int>(left.Count + right.Count);
            //Two pointers
            int r = 0;
            int l = 0;

            while (r < right.Count || l < left.Count)
            {
                //Not at end of either list
                if (r < right.Count && l < left.Count)
                    if (right[r] < left[l])
                        buffer.Add(right[r++]);
                    else
                        buffer.Add(left[l++]);

                //at end of right list
                else if (r >= right.Count)
                    while (l < left.Count)
                        buffer.Add(left[l++]);

                //must be at end of left...
                else
                    while (r < right.Count)
                        buffer.Add(right[r++]);
            }
            return buffer;
        }
    }
}
