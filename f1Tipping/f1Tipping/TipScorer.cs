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
        private Formula1Api f1Api;

        public TipScorer()
        {
            f1Api = new Formula1Api();

            raceResultsList = f1Api.RetrieveRaceResults(2016, 1);
            qualifyingResultsList = f1Api.RetrieveQualiyingResults(2016, 1);
        }

        public int ScoreTip(string tippedWinner, string tippedPole)
        {
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
