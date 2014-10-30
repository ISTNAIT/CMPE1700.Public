using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_8___Binary_IO_and_Serialization
{
    [Serializable]
    public struct Dice
    {
        public Die DieOne;
        public Die DieTwo;

        public Dice(Random r, int max = 6)
        {
            DieOne = new Die(r, max);
            DieTwo = new Die(r, max);
        }

        public uint Value()
        {
            return (DieOne.Value + DieTwo.Value);
        }

        public override string ToString()
        {
            return Value().ToString();
        }
    }
}
