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

        //Non-crud1
        public double? AverageKillsInMatchOne()
        {
            return this.repo.ReadAll().Where(x => x.Player.MatchId == 1).Average(x => x.Kills);
        }

        //Non-crud2
        public double? MaxKills(int matchid)
        {
            return this.repo.ReadAll().Where(x => x.Player.MatchId == matchid).Max(x => x.Kills);
        }

        //Non-crud3
        public double? MinDeaths(int matchid)
        {
            return this.repo.ReadAll().Where(x => x.Player.MatchId == matchid).Min(x => x.Deaths);
        }

        
        

    }
}
