using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Text.Json.Serialization;

namespace PACRKS_HFT_2022231.Models
{
    public class Player
    {
        public Player(int playerId, string username, string rank, int statId, int characterId, int matchId)
        {
            Username = username;
            Rank = rank;
            StatId = statId;
            CharacterId = characterId;
            PlayerId = playerId;
            MatchId = matchId;

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }
        public string Username { get; set; }
        public string Rank { get; set; }
        [ForeignKey(nameof(Stats))]
        public int StatId { get; set; }
        [JsonIgnore]
        public virtual Stats Stat { get; set; }
        [ForeignKey(nameof(Characters))]
        public int CharacterId { get; set; }
        [JsonIgnore]
        public virtual Characters Character { get; set; }
        public int MatchId { get; set; }
        public virtual Matches Match { get; set; }

        public Player()
        {

        }


    }
}
