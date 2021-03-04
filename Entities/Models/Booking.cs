using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }
        [Column(TypeName = "integer")]
        public int Amount { get; set; }
        public DateTime PurchaseDate { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Username { get; set; }
        [JsonIgnore]
        [ForeignKey("MatchNavigation")]
        public int MatchId { get; set; }
        [InverseProperty("Bookings")]
        public virtual Match MatchNavigation { get; set; }
        [JsonIgnore]
        public virtual List<Ticket> Tickets { get; set; }

    }
}
