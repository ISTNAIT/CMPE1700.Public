using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_10___Linked_List
{
    //Important: Using a class because classes are references by default
    class Node
    {
        public int value;
        public Node next; //Actually a reference to a node, not a node inside this one

        public Node(int val)
        {
            value = val;
            next = null; //Null means not connected
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
