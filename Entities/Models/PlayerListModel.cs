using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class PlayerListModel
    {
        public int PlayerId { get; set; }
        public int Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Team { get; set; }
    }
}
