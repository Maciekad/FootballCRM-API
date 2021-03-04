using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class TicketListModel
    {
        public string Seat { get; set; }

        public Match Match { get; set; }

        public int Amount { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}
