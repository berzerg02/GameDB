using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace PACRKS_HFT_2022231.Models
{
    public class Player
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }
        public string Username { get; set; }
        public string Rank { get; set; }
        //[ForeignKey(nameof(Stats))]
        public int StatId { get; set; }
        public virtual Stats Stat { get; set; }
        //[ForeignKey(nameof(Characters))]
        public int CharacterId { get; set; }
        public virtual Characters Character { get; set; }
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }



    }
}
