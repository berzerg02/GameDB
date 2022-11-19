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
    public class CharactersController : ControllerBase
    {
        ICharactersLogic logic;
        public CharactersController(ICharactersLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Characters> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Characters Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Characters value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Characters value)
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
