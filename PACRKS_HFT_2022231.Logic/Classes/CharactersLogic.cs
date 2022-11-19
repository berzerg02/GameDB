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
    public class CharactersLogic : ICharactersLogic
    {
        IRepository<Characters> repo;
        public CharactersLogic(IRepository<Characters> repo)
        {
            this.repo = repo;
        }
        public void Create(Characters item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Characters Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Characters> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Characters item)
        {
            this.repo.Update(item);
        }
    }
}
