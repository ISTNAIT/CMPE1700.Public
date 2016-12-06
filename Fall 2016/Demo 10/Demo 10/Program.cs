using System;
using System.Collections.Generic; //Needed for collections
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Demo_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Person Daenarys = new Person();
            Daenarys.Name = "Daenarys Targaryen";
            Daenarys.Age = 22;
            Daenarys.Mass = 54;
            Daenarys.Height = 152;
            Daenarys.Hair = Color.WhiteSmoke;
            Daenarys.Eyes = EyeColour.Lavender;
            PrintPerson(Daenarys);
            //Console.WriteLine(Daenarys);

            //Vector (VECTOR, DARNIT) of int
            List<int> VictorTheVector = new List<int>(10);
            VictorTheVector.Add(12);
            VictorTheVector.Insert(0, 15);
            PrintTheVector(VictorTheVector);

            //List (YES, LIST)
            LinkedList<int> Ella = new LinkedList<int>(VictorTheVector);
            

            Ella.AddFirst(0);
            foreach (int i in Ella) Console.Write(i + ", ");
            Console.WriteLine();

            LinkedListNode<int> Current = Ella.First;
            while (Current.Next != null)
                Current = Current.Next;
            Console.WriteLine("Value of last node is " + Current.Value);

            VictorTheVector.Sort();
            PrintTheVector(VictorTheVector);



            Console.ReadKey();
        }

        static void PrintTheVector(List<int> l)
        {
            //for (int i = 0; i < l.Count; ++i)
            //Console.Write(l[i] + i<l.Count-1?",":"");

            foreach (int i in l)
                Console.Write(i + ", ");

            Console.WriteLine();
        }

        //Totally unnecessary (use a ToString() override)
        static void PrintPerson(Person p)
        {
            Console.WriteLine(p.Name
                + "("+ p.Gender + ", " + p.Age + ")"
                + ": " + p.Hair + ", " + p.Eyes +  " : "
                + p.Mass + "kg, " + p.Height + "cm");
        }
    }
}
