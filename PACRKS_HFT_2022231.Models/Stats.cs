using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACRKS_HFT_2022231.Models
{
    public class Stats
    {
        public Stats(float timePlayed, double kills, double deaths, double shotsFired, double shotsConnected, int statId)
        {
            TimePlayed = timePlayed;
            Kills = kills;
            Deaths = deaths;
            ShotsFired = shotsFired;
            ShotsConnected = shotsConnected;
            StatId = statId;
        }
        public Stats()
        {

        }

        public float TimePlayed { get; set; }
        public double Kills { get; set; }
        public double Deaths { get; set; }
        public double ShotsFired { get; set; }
        public double ShotsConnected { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatId { get; set; }
        public virtual Player Player { get; set; }
    }
}
