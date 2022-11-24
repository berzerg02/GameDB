using PACRKS_HFT_2022231.Logic.Interfaces;
using PACRKS_HFT_2022231.Models;
using PACRKS_HFT_2022231.Repository;
using System;
using System.Linq;

namespace PACRKS_HFT_2022231.Logic.Classes
{
    public class PlayerLogic : IPlayerLogic
    {
        IRepository<Player> repo;
        public PlayerLogic(IRepository<Player> repo)
        {
            this.repo = repo;
        }
        public void Create(Player item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Player Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Player> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Player item)
        {
            this.repo.Update(item);
        }

        //non-crud 4
        public double? PlayerKD(string playername)
        {
            return this.repo.ReadAll().Where(x => x.Username == playername).Sum(x => x.Stat.Kills / x.Stat.Deaths);
        }

        //non-crud 5
        public double? PlayerPlayedTime(string playername)
        {
            return this.repo.ReadAll().Where(x => x.Username == playername).Sum(x => x.Stat.TimePlayed);
        }
    }
}
