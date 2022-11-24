using PACRKS_HFT_2022231.Logic.Classes;
using PACRKS_HFT_2022231.Models;
using PACRKS_HFT_2022231.Repository;
using PACRKS_HFT_2022231.Repository.ModelRepositories;
using System;
using System.Linq;

namespace PACRKS_HFT_2022231
{
    class Program
    {
        static void Main(string[] args)
        {
            OverwatchDbContext db = new OverwatchDbContext();
            
            var stats = db.Set<Stats>();

            var chars = db.Set<Characters>();
            var match = db.Set<Matches>();
            var player = db.Set<Player>();

            var que1 = player.Select(x => x.Match.Type);
            StatsRepository repo = new StatsRepository(db);
            StatsLogic lrepo = new StatsLogic(repo);
            var avg = lrepo.AverageKillsInMatchOne();
            try
            {
                var maxkills = lrepo.MaxKills(3);
            }
            catch (Exception)
            {
                Console.WriteLine("Nincs ilyen match");
            }
            
                ;
            
        }
    }
}
