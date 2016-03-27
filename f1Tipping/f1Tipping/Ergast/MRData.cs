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

    }

    public class RaceTable
    {
        public Race[] Races { get; set; }
    }

    public class Race
    {
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
        public string DriverName { get; set; }

    }
}
