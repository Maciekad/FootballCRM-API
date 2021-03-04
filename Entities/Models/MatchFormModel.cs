using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class MatchFormModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Score { get; set; }
        public string Stadium { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
    }
}
