using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string fn; //File name
            List<string> words = new List<string>(); //Set of words
            List<WordFreq> wordfreqs = new List<WordFreq>();
            StreamReader sr;
            FileStream fs;
            BinaryFormatter bf = new BinaryFormatter();
            XmlSerializer xs = new XmlSerializer(typeof(List<WordFreq>));
            
            string line;

            //Get filename
            Console.Write("Filename?");
            fn = Console.ReadLine();
            if (File.Exists(fn))
            {
                try
                {
                    sr = new StreamReader(fn);
                    while ((line = sr.ReadLine()) != null)
                        words.AddRange(line.Split(" \t .,;!?:-".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries));
                    words.Sort();
                    sr.Close();

                    foreach (string word in words)
                    {
                        //Check if word already present
                        if (wordfreqs.Count > 0 && wordfreqs.Last().Word == word.ToLower())
                            wordfreqs.Last().Freq++;

                        else
                            wordfreqs.Add(new WordFreq(word.ToLower(), 1));
                    }

                    //Save the data
                    fs = new FileStream(fn + ".dat", FileMode.Create, FileAccess.Write);
                    bf.Serialize(fs, wordfreqs);
                    fs.Close();
                    fs = new FileStream(fn + ".xml", FileMode.Create, FileAccess.Write);
                    xs.Serialize(fs, wordfreqs);
                    fs.Close();


                    //empty memory
                    wordfreqs = null;

                    //retrieve the data
                    fs = new FileStream(fn + ".dat", FileMode.Open, FileAccess.Read);
                    wordfreqs = (List<WordFreq>) bf.Deserialize(fs);
                    fs.Close();

                    foreach (WordFreq wf in wordfreqs)
                        Console.WriteLine(wf);


                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Error opening file: " + e.Message);
                }
            }
            else
                Console.Error.WriteLine("File " + fn + " does not exist.  Bozo.");
        }
    }
}
