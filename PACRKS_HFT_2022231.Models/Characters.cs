using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACRKS_HFT_2022231.Models
{
    public class Characters
    {
        [Key]
        public string Name { get; set; }
        public List<string> Skins { get; set; }
        public string Type { get; set; }
        
    }
}
