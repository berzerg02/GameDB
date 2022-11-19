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
    public class MatchLogic : IMatchLogic
    {
        IRepository<Match> repo;
        public MatchLogic(IRepository<Match> repo)
        {
            this.repo = repo;
        }
        public void Create(Match item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Match Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Match> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Match item)
        {
            this.repo.Update(item);
        }
    }
}
