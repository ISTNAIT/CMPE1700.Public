using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Demo_10
{
    public enum EyeColour
    {
        Brown=1, Blue, Green=4, Hazel=8,
        Lavender =16, Black=32
    }

    public enum Gender
    {
        Female, Male
    }

    public struct Person
    {
        public String Name;
        public EyeColour Eyes;
        public Gender Gender;
        public System.Drawing.Color Hair;
        public uint Age;
        public double Mass;
        public double Height;

        public override string ToString()
        {
            return Name
                + "(" + Gender + ", " + Age + ")"
                + ": " + Hair + ", " + Eyes + " : "
                + Mass + "kg, " + Height + "cm";
        }
    }//No need for semi at end
}
