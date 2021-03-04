using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class BookingsListModel
    {
        public int Amount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username {get; set;}
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }


    }
}
