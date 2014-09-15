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

            Person Bob = new Person("Bob Dobbs", 192.66, 96.3);
            Bob.gender = Gender.Male;
            Bob.eyeColor = EyeColor.Green;
            Bob.age = 42;

            Bob.children = new Person[2];
            Bob.children[0].name = "Gertrude";
            Bob.children[0].gender = Gender.Female;
            Bob.children[1].name = "Fabian";
            Bob.children[1].gender = Gender.Male;

            Person Emily = new Person("Emily");
            Emily.children = Bob.children;  //Note! Reference type.  They share the set of kids.

            Console.WriteLine("Emily's second kid is " + Emily.children[1]);

            SexualReassignmentSurgery(Bob);

            Console.WriteLine("But not permanently: " + Bob);

            Bob = SexualReassignmentSurgeryForRealz(Bob);

            Console.WriteLine("Now, permanently:" + Bob);

            Console.WriteLine("If I change the gender of Bob's kid, it happens to Emily's kid, too:");

            Bob.children[1] = SexualReassignmentSurgeryForRealz(Bob.children[1]);

            Console.WriteLine("Emily's kid:" + Emily.children[1]);

            Console.Write("Press any Key"); Console.ReadKey();
              
        }

        static public void SexualReassignmentSurgery(Person person)
        {
            Console.Write(person + " has become ");
            person.gender = (Gender)(((int)person.gender + 1) % 2);
            //or, like
           // switch(person.gender)
                //case Gender.Male
                    //person.gender = Gender.Female;
            Console.WriteLine(person);
        }

        static public Person SexualReassignmentSurgeryForRealz(Person person)
        {
            Console.Write(person + " has become ");
            person.gender = (Gender)(((int)person.gender + 1) % 2);
            //or, like
            // switch(person.gender)
            //case Gender.Male
            //person.gender = Gender.Female;
            Console.WriteLine(person);
            return person;
        }


    }
}
