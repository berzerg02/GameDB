using PACRKS_HFT_2022231.Models;
using PACRKS_HFT_2022231.Repository;
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
            var match = db.Set<Match>();
            var player = db.Set<Player>();

            var que1 = player.Select(x => x.Match.Type);
            
            
        }
    }
}
