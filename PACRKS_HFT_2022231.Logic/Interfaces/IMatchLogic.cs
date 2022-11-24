using PACRKS_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACRKS_HFT_2022231.Logic.Interfaces
{
    public interface IMatchLogic
    {
        void Create(Matches item);
        void Delete(int id);
        Matches Read(int id);
        IQueryable<Matches> ReadAll();
        void Update(Matches item);
    }
}
