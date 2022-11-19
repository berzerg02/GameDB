using PACRKS_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACRKS_HFT_2022231.Repository.ModelRepositories
{
    public class CharactersRepository : Repository<Characters>, IRepository<Characters>
    {
        public CharactersRepository(OverwatchDbContext ctx) : base(ctx)
        {

        }

        public override Characters Read(int id)
        {
            return ctx.Characters.FirstOrDefault(x => x.CharacterId == id);
        }

        public override void Update(Characters item)
        {
            var old = Read(item.CharacterId);
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
