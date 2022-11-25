using Castle.DynamicProxy;
using PACRKS_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACRKS_HFT_2022231.Repository.ModelRepositories
{
    public class MatchRepository : Repository<Matches>, IRepository<Matches> 
    {
        public MatchRepository(OverwatchDbContext ctx) : base(ctx)
        {

        }

        public override Matches Read(int id)
        {
            return ctx.Match.FirstOrDefault(t => t.MatchId == id);
        }

        public override void Update(Matches item)
        {
            var old = Read(item.MatchId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(x => x.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
