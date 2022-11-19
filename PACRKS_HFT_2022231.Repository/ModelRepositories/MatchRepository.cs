using PACRKS_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACRKS_HFT_2022231.Repository.ModelRepositories
{
    class MatchRepository : Repository<Match>, IRepository<Match> 
    {
        public MatchRepository(OverwatchDbContext ctx) : base(ctx)
        {

        }

        public override Match Read(int id)
        {
            return ctx.Match.FirstOrDefault(t => t.MatchId == id);
        }

        public override void Update(Match item)
        {
            var old = Read(item.MatchId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
