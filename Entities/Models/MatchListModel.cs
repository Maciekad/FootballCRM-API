using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class MatchListModel
    {
        public int MatchId { get; set; }
        public DateTime Date { get; set; }
        public DateTime EndDate { get; set; }
        public string Score { get; set; }
        public string Stadium { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
    }
}
