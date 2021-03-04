using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class TicketFormModel
    {
        public string Seat { get; set; }

        public int MatchId { get; set; }

        public int Amount { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}
