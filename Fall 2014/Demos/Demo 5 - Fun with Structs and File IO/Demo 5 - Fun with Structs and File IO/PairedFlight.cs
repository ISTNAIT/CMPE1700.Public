using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_5___Fun_with_Structs_and_File_IO
{
    public struct PairedFlight
    {
        Aviator pilotInCommand;
        Aviator firstOfficer;
        int hours;
        DateTime date;
        string destination;

        public PairedFlight(Aviator pilot, Aviator firsto)
        {
            this.pilotInCommand = pilot;
            this.firstOfficer = firsto;
            hours = 0;
            date = DateTime.Now;
            destination = "CYEG";
        }

        public PairedFlight(Aviator pilot, Aviator firsto, string destination)
        {
            this.pilotInCommand = pilot;
            this.firstOfficer = firsto;
            hours = 0;
            date = DateTime.Now;
            this.destination = destination;
        }

        public PairedFlight(Aviator pilot, Aviator firsto, string destination, int hours)
        {
            this.pilotInCommand = pilot;
            this.firstOfficer = firsto;
            this.hours = hours;
            date = DateTime.Now;
            this.destination = destination;
        }

        public PairedFlight(Aviator pilot, Aviator firsto, string destination, int hours, DateTime date)
        {
            this.pilotInCommand = pilot;
            this.firstOfficer = firsto;
            this.hours = hours;
            this.date = date;
            this.destination = destination;
            
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {4} {3}"
                , pilotInCommand, firstOfficer, destination, date, hours);
        }
    }
}
