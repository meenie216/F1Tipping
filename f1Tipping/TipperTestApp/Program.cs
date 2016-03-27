using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using f1Tipping;

namespace TipperTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            var tipScorer = new TipScorer();
            sw.Stop();

            Console.WriteLine($"Setup took {sw.Elapsed.TotalSeconds} seconds");
            sw.Reset();
            string[] tippedWinner = { "Nico Rosberg","Rosberg","Hamilton","max_verstappen","vettel" };
            string[] tippedPole = { "Rosberg", "Hamilton", "max_verstappen", "vettel" };


            foreach (var w in tippedWinner)
            {
                foreach (var p in tippedPole)
                {
                    sw.Start();
                    var score = tipScorer.ScoreTip(w, p);
                    sw.Stop();
                    Console.WriteLine($"{w} to win, {p} on pole - scored: {score}");
                    Console.WriteLine($"Took {sw.Elapsed.TotalSeconds} seconds to score the tip...");

                    sw.Reset();
                }
            }

            Console.ReadLine();

        }
    }
}
