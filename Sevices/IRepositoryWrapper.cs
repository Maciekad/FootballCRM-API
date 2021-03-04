using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IBookingRepository Booking { get; }
        IMatchRepository Match { get; }
        IPlayerRepository Player { get; }
        ITeamRepository Team { get; }
        ITicketRepository Ticket { get; }

        void Save();
    }
}
