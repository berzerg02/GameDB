using Microsoft.AspNetCore.Mvc;
using PACRKS_HFT_2022231.Logic.Interfaces;
using PACRKS_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PACRKS_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        IMatchLogic logic;
        public MatchController(IMatchLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Matches> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Matches Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Matches value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Matches value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
