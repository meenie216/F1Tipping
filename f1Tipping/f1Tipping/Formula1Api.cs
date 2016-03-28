using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using f1Tipping.Ergast;
using Newtonsoft.Json;

namespace f1Tipping
{
    public class Formula1Api
    {
        const string raceResultsUri = "http://ergast.com/api/f1/{0}/{1}/results.json";
        const string qualifyingResultsUri = "http://ergast.com/api/f1/{0}/{1}/qualifying.json";

        const string driversListUri = "http://ergast.com/api/f1/{0}/drivers.json";
        const string raceListUri = "http://ergast.com/api/f1/{0}.json";

        private Ergast.Ergast MakeApiCall(Uri apiUri)
        {
            var client = new WebClient();
            var json = client.DownloadString(apiUri);

            Ergast.Ergast apiResult = JsonConvert.DeserializeObject<Ergast.Ergast>(json);

            return apiResult;
        }

        public List<string> RetrieveRaceResults(int year, int raceIndex)
        {
            var url = new Uri(string.Format(raceResultsUri, year, raceIndex));
            var apiResult = MakeApiCall(url);

            var results = apiResult.MRData.RaceTable.Races[0].Results.Select(r =>
                r.Driver.DriverId
             );

            return results.ToList();
        }


        public List<string> RetrieveQualiyingResults(int year, int raceIndex)
        {
            var url = new Uri(string.Format(qualifyingResultsUri, year, raceIndex));
            var apiResult = MakeApiCall(url);

            var results = apiResult.MRData.RaceTable.Races[0].QualifyingResults.Select(r =>
                r.Driver.DriverId
             );

            return results.ToList();
        }

        public List<Driver> RetrieveSeasonDrivers(int year)
        {
            var uri = new Uri(string.Format(driversListUri, 2016));

            var apiResult = MakeApiCall(uri);

            var drivers = apiResult.MRData.DriverTable.Drivers.ToList();

            return drivers;
        } 
    }
}
