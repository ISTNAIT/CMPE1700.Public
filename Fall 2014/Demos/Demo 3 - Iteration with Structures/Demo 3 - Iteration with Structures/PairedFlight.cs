using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_3___Iteration_with_Structures
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

        public override string ToString()
        {
            return string.Format("Flight to {2} on {3} for {4} hours, {0} commanding, {1} first officer."
                ,pilotInCommand,firstOfficer,destination,date,hours);
        }
    }
}
