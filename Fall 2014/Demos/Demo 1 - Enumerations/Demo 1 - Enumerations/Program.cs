using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_1___Enumerations
{
    class Program
    {
        //Valid human eye colors, based on Martin Scale (Phys. Anthro)
        public enum EyeColor
        {
            Amber,
            Blue,
            Brown,
            Gray,
            Green,
            Hazel,
            Red,
            Violet,
            Black
        };

        static void Main(string[] args)
        {
            EyeColor ThoseEyes = EyeColor.Amber;
            Console.WriteLine("First Eyecolor is {0}", ThoseEyes);

            //What about all of them?
            Console.WriteLine("The valid set of eye colors, in order, are:");
            foreach(EyeColor eyecol in Enum.GetValues(typeof(EyeColor)))
            {
                Console.WriteLine(eyecol);
            }

            //Another way to do that, maybe....

            Console.WriteLine("The valid set of eye colors, in order, are:");
            for (EyeColor eyecol = EyeColor.Amber; eyecol <= EyeColor.Violet; ++eyecol )
                Console.WriteLine(eyecol);

            //How about doing it by incrementing?
            Console.WriteLine("The valid set of eye colors, in order, are:");
            EyeColor eyecolor = EyeColor.Amber;
            for (int i = 0; i < 1000; ++i )
            {
                Console.WriteLine(eyecolor);
                eyecolor++;
                //Fancy way of using % to wrap around (you guys really should know this, very useful)
                eyecolor = (EyeColor) ((int)eyecolor % Enum.GetNames(typeof(EyeColor)).Length);
            }


            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
