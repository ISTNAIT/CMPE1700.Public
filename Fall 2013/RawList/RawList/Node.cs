using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RawList
{
    public class Node
    {
        public string Value;
        public Node Next;

        public Node()
        {
            Value = "";
            Next = null;
        }

        public Node(string s)
        {
            Value = s;
            Next = null;
        }

        public Node(string s, Node n)
        {
            Value = s;
            Next = n;
        }
    }
}
