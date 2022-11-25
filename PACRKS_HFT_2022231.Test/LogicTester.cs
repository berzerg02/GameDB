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
            mockStatsRepo.Setup(x => x.ReadAll()).Returns(new List<Stats>()
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
            mockPlayerRepo.Setup(x => x.ReadAll()).Returns(new List<Player>()
            {
            new Player(1, "Wasman", "Plastic", 1, 1, 1)
            {
                Stat= new Stats(15f, 15, 5, 10000, 1210, 1)
            }
            }.AsQueryable());

            mockCharacterRepo = new Mock<IRepository<Characters>>();
            mockMatchesRepo = new Mock<IRepository<Matches>>(); 

            logic = new StatsLogic(mockStatsRepo.Object);
            playerlogic = new PlayerLogic(mockPlayerRepo.Object);
            characterlogic = new CharactersLogic(mockCharacterRepo.Object);
            matchlogic = new MatchLogic(mockMatchesRepo.Object);
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
            Stats sample = new Stats(16f, 20, 14, 120121, 121212, 1);

            logic.Create(sample);
            mockStatsRepo.Verify(x => x.Create(sample), Times.Once);

        }

        [Test]
        public void Create2()
        {
            Player sample = new Player(1, "Wasman", "Plastic", 1, 1, 1);

            playerlogic.Create(sample);
            mockPlayerRepo.Verify(x => x.Create(sample), Times.Once);

        }

        [Test]
        public void Create3()
        {
            Characters sample = new Characters(1, "Mate", "Csunya", "MateCsunya");

            characterlogic.Create(sample);
            mockCharacterRepo.Verify(x => x.Create(sample), Times.Once);

        }

        [Test]
        public void Create4()
        {
            Matches sample = new Matches(1, 20f, "Dorado", "Ranked");

            matchlogic.Create(sample);
            mockMatchesRepo.Verify(x => x.Create(sample), Times.Once);

        }

        [Test]
        public void Delete()
        {
            logic.Delete(1);
            mockStatsRepo.Verify(x => x.Delete(1), Times.Once);
        }
    }
}
