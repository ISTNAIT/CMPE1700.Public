using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_8___Binary_IO_and_Serialization
{
    [Serializable]
    public struct Die
    {
        public uint Value;
        
        public Die (Random r, int max = 6)
        {
            Value = (uint)r.Next(max)+1;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
