using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACRKS_HFT_2022231.Models
{
    public class Stats
    {
        public float TimePlayed { get; set; }
        public double Kills { get; set; }
        public double Deaths { get; set; }
        public double ShotsFired { get; set; }
        public double ShotsConnected { get; set; }
        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
    }
}
