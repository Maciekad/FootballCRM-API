using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Manager { get; set; }
        [JsonIgnore]
        public virtual List<Player> Players { get; set; }
        [JsonIgnore]
        public virtual List<Match> HomeMatches { get; set; }
        [JsonIgnore]
        public virtual List<Match> AwayMatches { get; set; }
    }
}
