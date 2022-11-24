using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACRKS_HFT_2022231.Models
{
    public class Characters
    {
        public Characters(int characterId, string name, string skin, string type)
        {
            CharacterId = characterId;
            Name = name;
            Skin = skin;
            Type = type;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string Skin { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Player> Players { get; set; }

        public Characters()
        {

        }
    }
}
