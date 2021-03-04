using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class PlayerFormModel
    {
        public int Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int TeamId { get; set; }
    }
}
