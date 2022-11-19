using PACRKS_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACRKS_HFT_2022231.Logic.Interfaces
{
    public interface ICharactersLogic
    {
        void Create(Characters item);
        void Delete(int id);
        Characters Read(int id);
        IQueryable<Characters> ReadAll();
        void Update(Characters item);
    }
}
