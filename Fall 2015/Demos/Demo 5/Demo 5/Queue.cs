using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_5
{
    class Queue
    {
        static public Node Enqueue(Node queue, string value)
        {
            //Add to tail
            return List.Add(queue, value, -1);
        }

        static public Node Dequeue(Node queue, out string value)
        {
            return Stack.Pop(queue, out value);
        }

        static public string Peek(Node queue)
        {
            return Stack.Peek(queue);
        }
    }
}
