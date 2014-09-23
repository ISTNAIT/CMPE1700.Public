using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Demo_5___Fun_with_Structs_and_File_IO
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int pilotCount = Enum.GetValues(typeof(Aviator)).Length;
            List<PairedFlight> flights = new List<PairedFlight>();

            foreach (Aviator pilot in Enum.GetValues(typeof(Aviator)))
            {
                for (Aviator firsto = pilot + 1; firsto <= (Aviator)(pilotCount - 1); firsto++)
                {
                    flights.Add(new PairedFlight(pilot, firsto, "YEG", 2));
                }
            }

            if (!SaveFlightsToDisk(flights))
            {
                Console.Error.WriteLine("Something went wrong. Exiting due to broken.");
                System.Environment.Exit(-1); // Gracefully choose to crash.
            }

            flights = null; //Destroy the nice set I so carefull built.

            if((flights = ReadFlightsFromDisk())== null)
            {
                Console.Error.WriteLine("Something went wrong. Exiting due to broken.");
                System.Environment.Exit(-1); // Gracefully choose to crash.
            }

            foreach (PairedFlight flight in flights)
                Console.WriteLine(flight);



            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        static bool SaveFlightsToDisk(List<PairedFlight> flights, string fileName = "Flights.txt")
        {
            StreamWriter sw;
            try
            {
                sw = new StreamWriter(fileName);

                foreach (PairedFlight flight in flights)
                    sw.WriteLine(flight);
                sw.Close();
            }

            catch (Exception ex)
            {
                Console.Error.WriteLine("AIIIEEEE!  HORRORS! Something went wrong: {0}", ex.Message);
                return false;
            }

            return true;
        }

        static List<PairedFlight> ReadFlightsFromDisk(string fileName = "Flights.txt")
        {
            List<PairedFlight> flights = new List<PairedFlight>();
            try
            {
                string line = null;
                StreamReader sr = new StreamReader(fileName);
                while((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split();
                    Aviator pilot = (Aviator)Enum.Parse(typeof(Aviator),values[0]);
                    Aviator firsto = (Aviator)Enum.Parse(typeof(Aviator), values[1]);
                    string destination = values[2];
                    int hours = int.Parse(values[3]);
                    DateTime date = DateTime.Parse(values[4] + ' ' + values[5]);
                    flights.Add(new PairedFlight(pilot,firsto,destination,hours,date));
                }

            }

            catch (Exception ex)
            {
                Console.Error.WriteLine("AIIIEEEE!  HORRORS! Something went wrong: {0}", ex.Message);
                return null;
            }
            
            return flights;
        }
    }
}
