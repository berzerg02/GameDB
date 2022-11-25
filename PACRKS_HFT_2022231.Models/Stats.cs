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
        public Stats(float timePlayed, double kills, double deaths, double shotsFired, double shotsConnected, int statid)
        {
            TimePlayed = timePlayed;
            Kills = kills;
            Deaths = deaths;
            ShotsFired = shotsFired;
            ShotsConnected = shotsConnected;
            StatId = statid;
        }
        public Stats()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatId { get; set; }
        //[Required]
        public float TimePlayed { get; set; }
        [Required]
        public double Kills { get; set; }
        //[Required]
        public double Deaths { get; set; }
        //[Required]
        public double ShotsFired { get; set; }
        //[Required]
        public double ShotsConnected { get; set; }
        [NotMapped]
        public virtual Player Player { get; set; }
    }
}
