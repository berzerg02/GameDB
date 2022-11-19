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
        void Create(Match item);
        void Delete(int id);
        Match Read(int id);
        IQueryable<Match> ReadAll();
        void Update(Match item);
    }
}
