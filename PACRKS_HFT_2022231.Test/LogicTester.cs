using Moq;
using NUnit.Framework;
using PACRKS_HFT_2022231.Logic.Classes;
using PACRKS_HFT_2022231.Models;
using PACRKS_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PACRKS_HFT_2022231.Test
{
    [TestFixture]
    public class LogicTester
    {
        StatsLogic logic;
        Mock<IRepository<Stats>> mockStatsRepo;

        PlayerLogic playerlogic;
        Mock<IRepository<Player>> mockPlayerRepo;

        CharactersLogic characterlogic;
        Mock<IRepository<Characters>> mockCharacterRepo;

        MatchLogic matchlogic;
        Mock<IRepository<Matches>> mockMatchesRepo;



        [SetUp]
        public void Init()
        {
            mockStatsRepo = new Mock<IRepository<Stats>>();
            mockStatsRepo.Setup(m => m.ReadAll()).Returns(new List<Stats>()
            {
            new Stats(15f, 15, 5, 1222,32,1)
            {
                   Player = new Player(1, "Wasman", "Plastic", 1, 1, 1)
                   {
                        Match = new Matches(1, 15f, "Dorado", "Ranked")
                   }
            },
            new Stats(16f, 25, 10, 12322, 3211, 2)
            { 
                Player = new Player(2, "Wolverine", "Gold", 2, 2, 1)
                { 
                    Match = new Matches(1, 15f, "Dorado", "Ranked")
                }
            }
            }.AsQueryable());

            mockPlayerRepo = new Mock<IRepository<Player>>();
            mockPlayerRepo.Setup(m => m.ReadAll()).Returns(new List<Player>()
            {
            new Player(1, "Wasman", "Plastic", 1, 1, 1)
            {
                Stat= new Stats(15f, 15, 5, 10000, 1210, 1)
            }
            }.AsQueryable());







            //mockStatsRepo = new Mock<IRepository<Stats>>();
            //mockStatsRepo.Setup(m => m.ReadAll()).Returns(new List<Stats>()
            //{
            //    new Stats() {Kills = 100, Deaths = 2, ShotsFired = 100000, ShotsConnected = 100, TimePlayed = 30f, StatId = 8},
            //    new Stats() {Kills = 20, Deaths = 10, ShotsFired = 100, ShotsConnected = 100, TimePlayed = 29f, StatId = 1},
            //    new Stats() {Kills = 1, Deaths = 50, ShotsFired = 23142, ShotsConnected = 2312, TimePlayed = 26f, StatId = 2},
            //    new Stats() {Kills = 30, Deaths = 6, ShotsFired = 120012, ShotsConnected = 4221, TimePlayed = 28f, StatId = 3},
            //    new Stats() {Kills = 25, Deaths = 20, ShotsFired = 43242, ShotsConnected = 1231, TimePlayed = 30f, StatId = 4},
            //    new Stats() {Kills = 21, Deaths = 10, ShotsFired = 213123, ShotsConnected = 1221, TimePlayed = 31f, StatId = 5},
            //    new Stats() {Kills = 18, Deaths = 4, ShotsFired = 12312, ShotsConnected = 3422, TimePlayed = 28.6f, StatId = 6},
            //    new Stats() {Kills = 15, Deaths = 8, ShotsFired = 564564, ShotsConnected = 4533, TimePlayed = 29.7f, StatId = 7},
            //}.AsQueryable());

            //mockPlayerRepo = new Mock<IRepository<Player>>();
            //mockPlayerRepo.Setup(x => x.ReadAll()).Returns(new List<Player>()
            //{
            //    new Player() {Username = "SpooderMan", CharacterId = 1, MatchId = 1, Rank = "Plastic", StatId = 8, PlayerId = 8 },
            //    new Player() {Username = "Karvesz", CharacterId = 5, MatchId = 1, Rank = "Potato", StatId = 1, PlayerId = 1},
            //    new Player() {Username = "HatHelo", CharacterId = 8, MatchId = 1, Rank = "Grandmaster", StatId = 2, PlayerId = 2},
            //    new Player() {Username = "Rpq", CharacterId = 4, MatchId = 1, Rank = "Bronze", StatId = 3, PlayerId = 3},
            //    new Player() {Username = "Bundi", CharacterId = 3, MatchId = 1, Rank = "Silver", StatId = 4, PlayerId = 4},
            //    new Player() {Username = "iBronn", CharacterId = 7, MatchId = 1, Rank = "Gold", StatId = 5, PlayerId = 5},
            //    new Player() {Username = "Wolverine", CharacterId = 2, MatchId = 1, Rank = "Platinum", StatId = 6, PlayerId = 6},
            //    new Player() {Username = "Nesquik", CharacterId = 6, MatchId = 1, Rank = "Diamond", StatId = 7, PlayerId = 7}

            //}.AsQueryable());

            //mockMatchesRepo = new Mock<IRepository<Matches>>();
            //mockMatchesRepo.Setup(x => x.ReadAll()).Returns(new List<Matches>()
            //{
            //    new Matches() {Length = 35f, Map = "Dorado", MatchId = 1, Type = "Ranked"},
            //    new Matches() {Length = 30f, Map = "Havana", MatchId = 2, Type = "Casual"}
            //}.AsQueryable());




            logic = new StatsLogic(mockStatsRepo.Object);
            playerlogic = new PlayerLogic(mockPlayerRepo.Object);
           



        }

        [Test]
        public void AverageKillsInMatchOne()
        {
            double? avg = logic.AverageKillsInMatchOne();
            Assert.That(avg, Is.EqualTo(20));
        }

        [Test]
        public void MaxKills()
        {
            double? max = logic.MaxKills(1);
            Assert.That(max, Is.EqualTo(25));
        }

        [Test]
        public void MinDeaths()
        {

            double? min = logic.MinDeaths(1);
            Assert.That(min, Is.EqualTo(5));

        }

        [Test]
        public void PlayerKD()
        {
            double? kd = playerlogic.PlayerKD("Wasman");
            Assert.That(kd, Is.EqualTo(3));
        }

        [Test]
        public void PlayerPLayedTime()
        {
            double? player = playerlogic.PlayerPlayedTime("Wasman");
            Assert.That(player, Is.EqualTo(15));
        }

        [Test]
        public void Create()
        { 
            
        }
    }
}
