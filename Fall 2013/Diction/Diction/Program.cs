using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diction
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Dictionary<uint,Student> Dict = new Dictionary<uint, Student>();
            Dict.Add(123456, new Student("AJ Armstrong", 123456, Student.EyeColor.Bloodshot));
            Dict.Add(12345, new Student("Larry the Wonder Rat", 12345, Student.EyeColor.Green));
            Dict.Add(1234, new Student("Bob Dobbs", 1234, Student.EyeColor.Blue));
            Dict.Add(123, new Student("Daenarys", 123, Student.EyeColor.Lavender));
            Dict.Add(12, new Student("J. Random User", 12, Student.EyeColor.Hazel));

            foreach (KeyValuePair<uint,Student> k in Dict)
                Console.WriteLine("Item " + k.Key + " is " + k.Value);

            Console.WriteLine("Item " + 123 + " is " + Dict[123]);

            Dict.Remove(12345);

            foreach (KeyValuePair<uint, Student> k in Dict)
                Console.WriteLine("Item " + k.Key + " is " + k.Value);

            if (Dict.ContainsKey(345))
                Console.WriteLine("Item " + 345 + " is " + Dict[345]);
            else
                Console.WriteLine("Item " + 345 + " is not present.");

            Console.WriteLine("Item " + 543 + " is " + (Dict.ContainsKey(543)?Dict[543].ToString():"Not Found"));
        }

        public struct Student
        {
            public enum EyeColor
            {
                Brown,
                Blue,
                Hazel,
                Green,
                Lavender, // Dragons!
                Bloodshot
            }

            public string Name;
            public uint StudentID;
            public EyeColor Eyes;

            public Student(string name, uint studentID, EyeColor eyes)
            {
                Name = name;
                StudentID = studentID;
                Eyes = eyes;
            }

            public override string ToString()
            {
                return Name + " (" + StudentID + ") has " + Eyes.ToString() + " eyes.";
            }
        }
    }
}

