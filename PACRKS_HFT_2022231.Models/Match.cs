using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PACRKS_HFT_2022231.Models
{
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchId { get; set; }
        public float Length { get; set; }
        public string Map { get; set; }
        public string Type { get; set; }
        [JsonIgnore]
        public virtual ICollection<Player> Players { get; set; }
    }
}
