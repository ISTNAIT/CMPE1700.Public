using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_5
{
    public class Stack
    {
        static public Node Push(Node stack,string value)
        {
            return List.Add(stack, value, 0);
        }

        static public Node Pop(Node stack, out string value)
        {
            if (stack == null)
            {
                value = "";
                return null;
            }

            value = stack.Value;
            Node newTop = stack.Next;
            if (newTop != null) newTop.Previous = null;
            return newTop;
        }

        static public string Peek(Node stack)
        {
            if (stack == null) throw new NullReferenceException("Stack is empty");
            return stack.Value;
        }
    }
}
