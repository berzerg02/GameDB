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
        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public OverwatchDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("OverwatchDatabase").UseLazyLoadingProxies();
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

                };

            var players = new Player[]
                {
                    new Player() {Username = "SpooderMan", CharacterId = 1, MatchId = 1, Rank = "Plastic", StatId = 0, PlayerId = 8 },
                    new Player() {Username = "Karvesz", CharacterId = 5, MatchId = 1, Rank = "Potato", StatId = 1, PlayerId = 1},
                    new Player() {Username = "HatHelo", CharacterId = 8, MatchId = 1, Rank = "Grandmaster", StatId = 2, PlayerId = 2},
                    new Player() {Username = "Rpq", CharacterId = 4, MatchId = 1, Rank = "Bronze", StatId = 3, PlayerId = 3},
                    new Player() {Username = "Bundi", CharacterId = 3, MatchId = 1, Rank = "Silver", StatId = 4, PlayerId = 4},
                    new Player() {Username = "iBronn", CharacterId = 7, MatchId = 1, Rank = "Gold", StatId = 5, PlayerId = 5},
                    new Player() {Username = "Wolverine", CharacterId = 2, MatchId = 1, Rank = "Platinum", StatId = 6, PlayerId = 6},
                    new Player() {Username = "Nesquik", CharacterId = 6, MatchId = 1, Rank = "Diamond", StatId = 7, PlayerId = 7},

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
                    new Stats() {Kills = 15, Deaths = 8, ShotsFired = 564564, ShotsConnected = 4533, TimePlayed = 29.7f, StatId = 7}


                };
            ;
            var match = new Match[]
                {
                    new Match() {Length = 35f, Map = "Dorado", MatchId = 1, Type = "Ranked"}

                };

            modelBuilder.Entity<Match>().HasData(match);
            modelBuilder.Entity<Player>().HasData(players);
            modelBuilder.Entity<Characters>().HasData(chars);
            modelBuilder.Entity<Stats>().HasData(stats);
        }
    }
}
