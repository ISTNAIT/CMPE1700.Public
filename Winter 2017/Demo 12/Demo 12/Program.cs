using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Demo_12
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 20;
            Random r = new Random();
            Node tree = null;

            for(int i = 0; i < n; ++i)
            {
                tree = AddToTree(tree, r.Next(n));
            }

            PrintTreeStructure(tree);
            Console.WriteLine();
            PrintInOrder(tree);
            Console.WriteLine();
            PrintPreOrder(tree);
            Console.WriteLine();
            PrintPostOrder(tree);


            if (Debugger.IsAttached) Console.ReadLine();
        }

        static public void PrintTreeStructure(Node tree, int levels = 10)
        {

            for (int i = 0; i < levels; ++i)
            {
                PrintTreeLevel(tree, i);
                Console.WriteLine();
            }
        }

        static public void PrintTreeLevel(Node tree, int level)
        {
            //Print the nodes at a given level, until no nodes
            if (tree == null)
            {
                Console.Write(" *");
                return;
            }
            if (level == 0)
            {
                Console.Write(" " + tree.ToString());
                return;
            }
            PrintTreeLevel(tree.Left, level - 1);
            PrintTreeLevel(tree.Right, level - 1);

        }

        static public void PrintInOrder(Node tree)
        {
            if (tree == null) return;
            PrintInOrder(tree.Left);
            Console.Write(tree.Value + " ");
            PrintInOrder(tree.Right);
        }

        static public void PrintPreOrder(Node tree)
        {
            if (tree == null) return;
            Console.Write(tree.Value + " ");
            PrintPreOrder(tree.Left);
            PrintPreOrder(tree.Right);
        }

        static public void PrintPostOrder(Node tree)
        {
            if (tree == null) return;
            PrintPostOrder(tree.Left);
            PrintPostOrder(tree.Right);
            Console.Write(tree.Value + " ");
        }
        static public Node AddToTree(Node root, int val)
        {
            //Did this guy just hand me a non-existant tree?
            if (root == null)
                return new Node(val);
            //We'll put duplicates to the left
            if (val <= root.Value) // This node belongs in the left subtree.
            {
                if (root.Left == null)
                {
                    root.Left = new Node(val);
                    return root;
                }
                AddToTree(root.Left, val);
                return root;
            }
            else
            {
                if (root.Right == null)
                {
                    root.Right = new Node(val);
                    return root;
                }
                AddToTree(root.Right, val);
                return root;
            }
        }
    }
}

