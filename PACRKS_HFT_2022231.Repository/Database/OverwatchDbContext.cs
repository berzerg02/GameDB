using Microsoft.EntityFrameworkCore;
using PACRKS_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACRKS_HFT_2022231.Repository
{
    public class OverwatchDbContext : DbContext
    {
        public virtual DbSet<Characters> Characters { get; set; }
        public virtual DbSet<Matches> Match { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Stats> Stat { get; set; }
        public OverwatchDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("OverwatchDatabase").UseLazyLoadingProxies();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(x => x.Match)
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.MatchId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Player>()
                .HasOne(x => x.Stat)
                .WithOne(x => x.Player)
                .HasForeignKey<Stats>(y => y.StatId);

            modelBuilder.Entity<Player>()
                .HasOne(x => x.Character)
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.CharacterId)
                .OnDelete(DeleteBehavior.Cascade);


            var chars = new Characters[]
                {
                    new Characters() {Name = "Moira", Skin = "Fiery", Type = "Support", CharacterId = 8},
                    new Characters() {Name = "D.Va", Skin = "Nano", Type = "Tank", CharacterId = 1},
                    new Characters() {Name = "Orisa", Skin = "Sunrise", Type = "Tank", CharacterId = 2},
                    new Characters() {Name = "Cassidy", Skin = "Riverboat", Type = "Dps", CharacterId = 3},
                    new Characters() {Name = "Soldier: 76", Skin = "Jet", Type = "Dps", CharacterId = 4},
                    new Characters() {Name = "Mercy", Skin = "Amber", Type = "Support", CharacterId = 5},
                    new Characters() {Name = "Echo", Skin = "Durlan", Type = "Dps", CharacterId = 6},
                    new Characters() {Name = "Widowmaker", Skin = "Dawn", Type = "Dps", CharacterId = 7},
                    new Characters() {Name = "Bastion", Skin = "Sky", Type = "Dps", CharacterId = 9},
                    new Characters() {Name = "Sigma", Skin = "Earth", Type = "Tank", CharacterId = 10},
                    new Characters() {Name = "Sombra", Skin = "Grass", Type = "Dps", CharacterId = 11},
                    new Characters() {Name = "Winston", Skin = "Sunset", Type = "Tank", CharacterId = 12},
                    new Characters() {Name = "Kariko", Skin = "Crystallic", Type = "Support", CharacterId = 13},
                    new Characters() {Name = "Lucio", Skin = "Blacked", Type = "Support", CharacterId = 14},
                    new Characters() {Name = "Tracer", Skin = "Mono", Type = "Dps", CharacterId = 15},
                    new Characters() {Name = "Ashe", Skin = "Scientific", Type = "Dps", CharacterId = 16},

                };

            var players = new Player[]
                {
                    new Player() {Username = "SpooderMan", CharacterId = 1, MatchId = 1, Rank = "Plastic", StatId = 8, PlayerId = 8 },
                    new Player() {Username = "Karvesz", CharacterId = 5, MatchId = 1, Rank = "Potato", StatId = 1, PlayerId = 1},
                    new Player() {Username = "HatHelo", CharacterId = 8, MatchId = 1, Rank = "Grandmaster", StatId = 2, PlayerId = 2},
                    new Player() {Username = "Rpq", CharacterId = 4, MatchId = 1, Rank = "Bronze", StatId = 3, PlayerId = 3},
                    new Player() {Username = "Bundi", CharacterId = 3, MatchId = 1, Rank = "Silver", StatId = 4, PlayerId = 4},
                    new Player() {Username = "iBronn", CharacterId = 7, MatchId = 1, Rank = "Gold", StatId = 5, PlayerId = 5},
                    new Player() {Username = "Wolverine", CharacterId = 2, MatchId = 1, Rank = "Platinum", StatId = 6, PlayerId = 6},
                    new Player() {Username = "Nesquik", CharacterId = 6, MatchId = 1, Rank = "Diamond", StatId = 7, PlayerId = 7},

                    new Player() {Username = "ManDingo", CharacterId = 9, MatchId = 2, Rank = "Diamond", StatId = 9, PlayerId = 9},
                    new Player() {Username = "HatHelo", CharacterId = 10, MatchId = 2, Rank = "Gold", StatId = 10, PlayerId = 10},
                    new Player() {Username = "Noroi", CharacterId = 11, MatchId = 2, Rank = "Platinum", StatId = 11, PlayerId = 11},
                    new Player() {Username = "Raven", CharacterId = 12, MatchId = 2, Rank = "Immortal", StatId = 12, PlayerId = 12},
                    new Player() {Username = "Beatlewhochewshgum", CharacterId = 13, MatchId = 2, Rank = "Grandmaster", StatId = 13, PlayerId = 13},
                    new Player() {Username = "Grandpachairgaming", CharacterId = 14, MatchId = 2, Rank = "Diamond", StatId = 14, PlayerId = 14},
                    new Player() {Username = "Spiderwit3legs", CharacterId = 15, MatchId = 2, Rank = "Diamond", StatId = 15, PlayerId = 15},
                    new Player() {Username = "Dinodog08", CharacterId = 16, MatchId = 2, Rank = "Diamond", StatId = 16, PlayerId = 16},

                };

            var stats = new Stats[]
                {
                    new Stats() {Kills = 100, Deaths = 2, ShotsFired = 100000, ShotsConnected = 100, TimePlayed = 30f, StatId = 8},
                    new Stats() {Kills = 20, Deaths = 10, ShotsFired = 100, ShotsConnected = 100, TimePlayed = 29f, StatId = 1},
                    new Stats() {Kills = 1, Deaths = 50, ShotsFired = 23142, ShotsConnected = 2312, TimePlayed = 26f, StatId = 2},
                    new Stats() {Kills = 30, Deaths = 6, ShotsFired = 120012, ShotsConnected = 4221, TimePlayed = 28f, StatId = 3},
                    new Stats() {Kills = 25, Deaths = 20, ShotsFired = 43242, ShotsConnected = 1231, TimePlayed = 30f, StatId = 4},
                    new Stats() {Kills = 21, Deaths = 10, ShotsFired = 213123, ShotsConnected = 1221, TimePlayed = 31f, StatId = 5},
                    new Stats() {Kills = 18, Deaths = 4, ShotsFired = 12312, ShotsConnected = 3422, TimePlayed = 28.6f, StatId = 6},
                    new Stats() {Kills = 15, Deaths = 8, ShotsFired = 564564, ShotsConnected = 4533, TimePlayed = 29.7f, StatId = 7},

                    new Stats() {Kills = 24, Deaths = 8, ShotsFired = 321231, ShotsConnected = 12312, TimePlayed = 22, StatId = 9},
                    new Stats() {Kills = 26, Deaths = 10, ShotsFired = 123123, ShotsConnected = 3122, TimePlayed = 23, StatId = 10},
                    new Stats() {Kills = 13, Deaths = 30, ShotsFired = 41231, ShotsConnected = 32131, TimePlayed = 24, StatId = 11},
                    new Stats() {Kills = 5, Deaths = 8, ShotsFired = 42313, ShotsConnected = 31231, TimePlayed = 25, StatId = 12},
                    new Stats() {Kills = 32, Deaths = 3, ShotsFired = 213123, ShotsConnected = 123123, TimePlayed = 26, StatId = 13},
                    new Stats() {Kills = 15, Deaths = 5, ShotsFired = 523324, ShotsConnected = 12312, TimePlayed = 27, StatId = 14},
                    new Stats() {Kills = 17, Deaths = 20, ShotsFired = 1231231, ShotsConnected = 3123, TimePlayed = 28, StatId = 15},
                    new Stats() {Kills = 20, Deaths = 30, ShotsFired = 123342, ShotsConnected = 12312, TimePlayed = 29.3f, StatId = 16}


                };
            ;
            var match = new Matches[]
                {
                    new Matches() {Length = 35f, Map = "Dorado", MatchId = 1, Type = "Ranked"},
                    new Matches() {Length = 30f, Map = "Havana", MatchId = 2, Type = "Casual"}

                };

            modelBuilder.Entity<Matches>().HasData(match);
            modelBuilder.Entity<Player>().HasData(players);
            modelBuilder.Entity<Characters>().HasData(chars);
            modelBuilder.Entity<Stats>().HasData(stats);
        }
    }
}
