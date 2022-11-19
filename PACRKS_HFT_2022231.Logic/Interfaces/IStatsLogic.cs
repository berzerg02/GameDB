using PACRKS_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACRKS_HFT_2022231.Logic.Interfaces
{
    public interface IStatsLogic
    {
        void Create(Stats item);
        void Delete(int id);
        Stats Read(int id);
        IQueryable<Stats> ReadAll();
        void Update(Stats item);
    }
}
