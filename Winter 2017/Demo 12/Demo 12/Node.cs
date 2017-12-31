using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_12
{
    public class Node
    {
        public int Value;
        public Node Left;
        public Node Right;

        public override string ToString()
        {
            return Value.ToString();
        }

        public Node(int val)
        {
            Value = val;
            Left = null;
            Right = null;
        }

        public Node ()
        {
            Value = 0;
            Left = null;
            Right = null;
        }
    }
}
