using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using f1Tipping.Ergast;
using Newtonsoft.Json;

namespace f1Tipping
{
    public class TipScorer
    {
        private List<string> raceResultsList;
        private List<string> qualifyingResultsList;

        public TipScorer()
        {
            raceResultsList = RetrieveRaceResults(1);
            qualifyingResultsList = RetrieveQualifyingResults(1);
        }

        private List<string> RetrieveRaceResults(int raceIndex)
        {
            const string resultsUrl = "http://ergast.com/api/f1/2016/{0}/results.json";

            var apiUrl = string.Format(resultsUrl, raceIndex);

            var client = new WebClient();
            var json = client.DownloadString(apiUrl);

            Ergast.Ergast raceResults = JsonConvert.DeserializeObject<Ergast.Ergast>(json);

            var results = raceResults.MRData.RaceTable.Races[0].Results.Select(r =>
                r.Driver.DriverId
                );

            return results.ToList();
        }

        private List<string> RetrieveQualifyingResults(int raceIndex)
        {
            const string resultsUrl = "http://ergast.com/api/f1/2016/{0}/qualifying.json";

            var apiUrl = string.Format(resultsUrl, raceIndex);

            var client = new WebClient();
            var json = client.DownloadString(apiUrl);

            Ergast.Ergast raceResults = JsonConvert.DeserializeObject<Ergast.Ergast>(json);

            var results = raceResults.MRData.RaceTable.Races[0].QualifyingResults.Select(r =>
                r.Driver.DriverId
                );

            return results.ToList();
        }

/*
        private List<string> raceResultsList = new List<string>
        {
            "rosberg",
            "hamilton",
            "vettel",
            "Riccardo",
            "Massa",
            "Grosjean",
            "Hulkenberg",
            "Bottas",
            "Sainz",
            "max_verstappen",
            "jolyon_palmer",
            "kevin_magnussen",
            "Perez",
            "Button",
            "Nasr",
            "Wehrlein",
            "Ericsson",
            "Raikkonen",
            "Haryanto",
            "gutierrez",
            "Alsonso",
            "Kyvat"
        };

        private List<string> qualifyingResultsList = new List<string>
        {
            "Hamilton",
            "Rosberg",
            "Vettel",
            "Raikkonen",
            "max_Verstappen",
            "Massa",
            "Sainz",
            "Ricciardo",
            "Perez",
            "Hulkenberg",
            "Bottas",
            "Alonso",
            "Button",
            "Jolyon_Palmer",
            "kevin_magnussen",
            "ericsson",
            "nasr",
            "kyvat",
            "grosjean",
            "guitierrez",
            "haryanto",
            "wehrlein"
        };
*/

        public int ScoreTip(string tippedWinner, string tippedPole)
        {
/*
            var normalisedResulst = raceResultsList.Select(i => i.ToLowerInvariant()).ToList();
            var normalisedQualificationResulst = qualifyingResultsList.Select(i => i.ToLowerInvariant()).ToList();*/

            var raceWinScore = raceResultsList.IndexOf(tippedWinner.ToLowerInvariant());
            var qualifyingScore = qualifyingResultsList.IndexOf(tippedPole.ToLowerInvariant());

            if (raceWinScore < 0)
                raceWinScore = raceResultsList.Count();
            if (qualifyingScore < 0)
                qualifyingScore = qualifyingResultsList.Count();

            var finalScore = raceWinScore + qualifyingScore;
            return finalScore;
        }
    }
}
