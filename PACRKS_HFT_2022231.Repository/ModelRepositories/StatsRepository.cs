using PACRKS_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACRKS_HFT_2022231.Repository.ModelRepositories
{
    public class StatsRepository : Repository<Stats>, IRepository<Stats>

    {
        public StatsRepository(OverwatchDbContext ctx) : base(ctx)
        {

        }

        public override Stats Read(int id)
        {
            return ctx.Stat.FirstOrDefault(x => x.StatId == id);
        }

        public override void Update(Stats item)
        {
            var old = Read(item.StatId);
            foreach (var helper in old.GetType().GetProperties())
            {
                if (helper.GetAccessors().FirstOrDefault(x => x.IsVirtual) == null)
                {
                    helper.SetValue(old, helper.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }


    }
}
