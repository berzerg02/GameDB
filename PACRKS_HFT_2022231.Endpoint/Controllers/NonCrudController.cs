using Microsoft.AspNetCore.Mvc;
using PACRKS_HFT_2022231.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PACRKS_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/action")]
    [ApiController]
    public class NonCrudController : Controller
    {
        IStatsLogic logic;
        IPlayerLogic playerlogic;

        public NonCrudController(IStatsLogic logic, IPlayerLogic playerlogic)
        {
            this.logic = logic;
            this.playerlogic = playerlogic;
        }


        [HttpGet]
        public double? AverageKillInMatchOne()
        {
            return this.logic.AverageKillsInMatchOne();
        }

        [HttpGet("{matchid}/forMaxKills")]
        public double? MaxKills(int matchid)
        {
            return this.logic.MaxKills(matchid);
        }
       
        [HttpGet("{matchid}/forMinDeaths")]
        public double? MinDeaths(int matchid)
        {
            return this.logic.MinDeaths(matchid);
        }
        
        [HttpGet("playerkd/{kdname}")]
        public double? PlayerKD(string kdname)
        {
            return this.playerlogic.PlayerKD(kdname);
        }

        [HttpGet("playertimeplayed/{playername}")]
        public double? PlayerPlayedTime(string playername)
        {
            return this.playerlogic.PlayerPlayedTime(playername);
        }

    }
}
