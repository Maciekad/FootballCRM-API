using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Match
    {
        [Key]
        public int MatchId { get; set; }
        public DateTime Date { get; set; }
        public DateTime EndDate { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string Score { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Stadium { get; set; }
        [JsonIgnore]
        [ForeignKey("HomeTeamNavigation")]
        public int? HomeTeamId { get; set; }
        [InverseProperty("HomeMatches")]
        public virtual Team HomeTeamNavigation { get; set; }
        [JsonIgnore]
        [ForeignKey("AwayTeamNavigation")]
        public int? AwayTeamId { get; set; }
        
        [InverseProperty("AwayMatches")]
        public virtual Team AwayTeamNavigation { get; set; }
        [JsonIgnore]
        public virtual List<Booking> Bookings { get; set; }
    }
}
