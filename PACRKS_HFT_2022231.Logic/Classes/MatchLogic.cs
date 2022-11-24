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
        IRepository<Matches> repo;
        public MatchLogic(IRepository<Matches> repo)
        {
            this.repo = repo;
        }
        public void Create(Matches item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Matches Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Matches> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Matches item)
        {
            this.repo.Update(item);
        }
    }
}
