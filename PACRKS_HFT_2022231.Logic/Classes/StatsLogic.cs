using PACRKS_HFT_2022231.Logic.Interfaces;
using PACRKS_HFT_2022231.Models;
using PACRKS_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACRKS_HFT_2022231.Logic.Classes
{
    public class StatsLogic : IStatsLogic
    {
        IRepository<Stats> repo;
        public StatsLogic(IRepository<Stats> repo)
        {
            this.repo = repo;
        }
        public void Create(Stats item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Stats Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Stats> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Stats item)
        {
            this.repo.Update(item);
        }
    }
}
