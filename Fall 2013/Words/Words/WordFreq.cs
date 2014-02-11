using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Words
{
    [Serializable]
    public class WordFreq 
    {
        public string Word;
        public int Freq;

        //Default ctor
        public WordFreq()
        {
            Word = "";
            Freq = 0;
        }

        //Parameterized ctor
        public WordFreq(string w, int f)
        {
            Word = w;
            Freq = f;
        }

        //ToString method
        public override string ToString()
        {
            return Word + " " + Freq.ToString();
        }

    }
}
