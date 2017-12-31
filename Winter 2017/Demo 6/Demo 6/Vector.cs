using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Demo_6
{
    public struct Vector
    {
        public int[] Store; //Current Storage
        public int Max; //Current size of store
        public int Size; //Used portion

        public static Vector Initialize(int max=10)
        {
            Vector retval = new Vector();
            retval.Store = new int[max];
            retval.Size = 0;
            retval.Max = max;
            return retval;
        }

        //Grow by a factor
        public static Vector Grow(Vector vec, int factor = 2)
        {
            if (factor < 2)
                throw new 
                    ArgumentOutOfRangeException("Grow factor must be at least 2");
            if (Debugger.IsAttached)
            {
                Console.WriteLine("Growing vector from size "
                    + vec.Max + " to " + vec.Max * factor);
            }
            //Get a new store...
            int[] newstore = new int[vec.Max * factor];
            for (int i = 0; i < vec.Size; i++)
                newstore[i] = vec.Store[i];
            vec.Max = vec.Max * factor;
            vec.Store = newstore;
            //No new items, so no need to change size
           
            return vec;
        }

        //Add to end
        public static Vector Add(Vector vec, int value)
        {
            //Check if the vector I got is valid...
            if(vec.Store == null)
                throw new NullReferenceException("Vector store is null");

            //Do I need to grow?
            if (vec.Size == vec.Max) vec = Grow(vec);
            vec.Store[vec.Size] = value;
            vec.Size++;
            return vec;
        }


        static public Vector Insert(Vector v, int value, int index)
        {
            return v;
        }

        static public Vector Delete(Vector v, int index)
        {
            return v;
        }
    }
}
