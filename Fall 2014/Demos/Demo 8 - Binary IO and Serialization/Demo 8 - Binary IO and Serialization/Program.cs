using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace Demo_8___Binary_IO_and_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            FileStream fs;
            BinaryWriter bw;
            BinaryReader br;
            BinaryFormatter bf;
            XmlSerializer xs;

            List<Dice> Rolls = new List<Dice>(100);
            List<Dice> RollsFromSerial = null;
            List<Dice> RollsFromXML = null;

            for (int i = 0; i < 100; ++i)
                Rolls.Add(new Dice(r));

            //Store using binary file i/o
            try
            {
                fs = new FileStream("Binary.bin", FileMode.Create, FileAccess.Write);
                bw = new BinaryWriter(fs);
                foreach (Dice d in Rolls)
                    bw.Write(d.Value());
                fs.Close();
                //Now, retrieve and print

                fs = new FileStream("Binary.bin", FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
                long numValues = fs.Length / sizeof(uint);
                for (int i = 0; i < numValues; ++i)
                    Console.WriteLine(br.ReadUInt32());
                fs.Close();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Something bad: " + e.Message);
                Environment.Exit(-1);
            }

            //Store using binary serialization

            try
            {
                bf = new BinaryFormatter();
                fs = new FileStream("Serial.dat", FileMode.Create, FileAccess.Write);
                bf.Serialize(fs, Rolls);
                fs.Close();

                fs = new FileStream("Serial.dat", FileMode.Open, FileAccess.Read);
                RollsFromSerial = (List<Dice>)bf.Deserialize(fs);
                fs.Close();
                foreach (Dice d in RollsFromSerial)
                    Console.WriteLine(d);

            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Something bad: " + e.Message);
                Environment.Exit(-2);
            }

            try
            {
                fs = new FileStream("Rolls.xml", FileMode.Create, FileAccess.Write);
                xs = new XmlSerializer(typeof(List<Dice>));
                xs.Serialize(fs, Rolls);
                fs.Close();

                fs = new FileStream("Rolls.xml", FileMode.Open, FileAccess.Read);
                RollsFromXML = (List<Dice>)xs.Deserialize(fs);
                fs.Close();
                foreach (Dice d in RollsFromXML)
                    Console.WriteLine(d);

            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Something bad: " + e.Message);
                Environment.Exit(-3);
            }
            Console.ReadKey();

        }
    }
}
