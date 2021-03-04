using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        private RepositoryContext _repoContext;
        private IBookingRepository _booking;
        private IMatchRepository _match;
        private IPlayerRepository _player;
        private ITicketRepository _ticket;
        private ITeamRepository _team;

        public IBookingRepository Booking
        {
            get
            {
                if (_booking == null)
                {
                    _booking = new BookingRepository(_repoContext);
                }
                return _booking;
            }
        }
        public IMatchRepository Match
        {
            get
            {
                if (_match == null)
                {
                    _match = new MatchRepository(_repoContext);
                }
                return _match;
            }
        }
        public IPlayerRepository Player
        {
            get
            {
                if (_player == null)
                {
                    _player = new PlayerRepository(_repoContext);
                }
                return _player;
            }
        }
        public ITicketRepository Ticket
        {
            get
            {
                if (_ticket == null)
                {
                    _ticket = new TicketRepository(_repoContext);
                }
                return _ticket;
            }
        }

        public ITeamRepository Team
        {
            get
            {
                if (_team == null)
                {
                    _team = new TeamRepository(_repoContext);
                }
                return _team;
            }
        }
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
