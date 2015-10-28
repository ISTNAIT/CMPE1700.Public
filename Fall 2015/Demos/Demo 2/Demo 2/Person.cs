using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Demo_2
{
    public enum EyeColour
    {
        Brown,
        Blue,
        Green,
        Hazel,
        Grey,
        Pink,
        Violet
    }

    public struct Person
    {
        public string Name;
        public uint ID;
        public uint Age;
        public DateTime BirthDate;
        public Color HairColor;
        public EyeColour EyeCol;
        public double Height;
        public double Mass;

        public override string ToString()
        {
            return Name + " (" + Age + ")";
        }
    }
}
