using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string Seat { get; set; }
        [JsonIgnore]
        public int BookingId { get; set; }
        [InverseProperty("Tickets")]
        public virtual Booking BookingNavigation { get; set; }
    }
}
