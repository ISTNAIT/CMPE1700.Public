using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_2___Basic_Structures
{
    class Program
    {
        public enum Gender { Female, Male };
        public enum EyeColor
        {
            Amber,
            Blue,
            Brown,
            Gray,
            Green,
            Hazel,
            Red,
            Violet
        };


        public struct Person
        {
            public string name;
            public double height;
            public double weight;
            public uint age;
            public Gender gender;
            public EyeColor eyeColor;
            public Person[] children;

            public Person(string name , double height = 0.0 , double weight = 0.0)
            {
                //Use this to get at the member variable, if it is shadowed by a local variable
                this.name = name;
                this.height = height;
                this.weight = weight;
                age = 17;
                gender = Gender.Female;
                eyeColor = EyeColor.Brown;
                children = null;
            }

            public override string ToString()
            {
                return string.Format("{0} ({2}, {1} years old)", name, age, gender);
            }

        }

        static void Main(string[] args)
        {
            //Smoke test
            Console.WriteLine(new Person()); //Anonymous doomed new Person who exists just long enough to be printed.
            Console.WriteLine(new Person("Sally")); //Same again, but without default ctor.

            Console.Write("Press any Key"); Console.ReadKey();
        }
    }
}
