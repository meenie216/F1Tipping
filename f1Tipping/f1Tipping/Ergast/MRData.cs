using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1Tipping.Ergast
{
    public class Ergast
    {
        public MRData MRData { get; set; }
    }


    public class MRData
    {
        public RaceTable RaceTable { get; set; }

        public DriverTable DriverTable { get; set; }
    }

    public class DriverTable
    {
        public Driver[] Drivers { get; set; }
    }

    public class RaceTable
    {
        public Race[] Races { get; set; }
    }

    public class Race
    {
        public string RaceName { get; set; }

        public string  Date { get; set; }
        public string Time { get; set; }

        public DateTime RaceTime => DateTime.Parse($"{Date} {Time}");

        public Results[] Results { get; set; }

        public Results[] QualifyingResults { get; set; }
    }

    public class Results
    {
        public Driver Driver { get; set; }
    }

    public class Driver
    {
        public string DriverId { get; set; }
        public string DriverName => $"{this.GivenName} {this.FamilyName}";

        public string GivenName { get; set; }
        public string FamilyName { get; set; }
    }
}
