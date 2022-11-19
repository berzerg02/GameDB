using PACRKS_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACRKS_HFT_2022231.Repository.ModelRepositories
{
    public class PlayerRepository : Repository<Player>, IRepository<Player>
    {
        public PlayerRepository(OverwatchDbContext ctx) : base(ctx)
        {

        }

        public override Player Read(int id)
        {
            return ctx.Player.FirstOrDefault(x => x.PlayerId == id);
        }

        public override void Update(Player item)
        {
            var old = Read(item.PlayerId);
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
