using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Demo_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person Me = new Person();
            Me.Age = 29;
            Me.BirthDate = new DateTime(1928, 11, 13);
            Me.EyeCol = EyeColour.Brown;
            Me.Height = 115;
            Me.Mass = 100.0;
            Me.ID = 100456;
            Me.Name = "AJ Armstrong";
            Me.HairColor = System.Drawing.Color.Fuchsia;

            SayHi(Me);

            SayHi(BestFriend());

            Console.WriteLine(Me);

            Console.WriteLine(EyeColour.Hazel);

            PrintEyeColors();

            //Create an array of structs:

            Person[] People = new Person[Enum.GetValues(typeof(EyeColour)).Length];
            int index = 0;

            foreach (EyeColour e in Enum.GetValues(typeof(EyeColour)))
            {
                People[index].EyeCol = e;
                People[index++].Name = e.ToString();
            }

            foreach (Person p in People)
                Console.WriteLine(p);

                Console.ReadKey();
        }

        static void SayHi(Person pers)
        {
            Console.Write("The person in front of you (" + pers + ") " + (pers.Height < 150 ? ", who is pretty short, " : ""));
            Console.WriteLine(pers.Name = "says hi.");
        }

        static Person BestFriend()
        {
            //Creates a person and returns it
            Person bf = new Person();
            bf.Name = "Barney Rubble";
            return bf;
        }

        static void PrintEyeColors ()
        {
            //Iterate Through all the eyecolors
            foreach (EyeColour e in Enum.GetValues(typeof(EyeColour)))
            { 
                Console.WriteLine(e);
            }

        }
    }
}
