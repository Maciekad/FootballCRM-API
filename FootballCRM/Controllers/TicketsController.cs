using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Contracts;

namespace Entities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public TicketsController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketListModel>>> GetTickets()
        {
            var tickets = await _repository.Ticket.GetAll();

            var ticketsList = tickets
                .Select(x => new TicketListModel
                {
                    Seat = x.Seat,
                    Match = x.BookingNavigation.MatchNavigation,
                    Amount = x.BookingNavigation.Amount,
                    FirstName = x.BookingNavigation.FirstName,
                    LastName = x.BookingNavigation.LastName,
                    Username = x.BookingNavigation.Username,
                    Email = x.BookingNavigation.Email,
                    PurchaseDate = x.BookingNavigation.PurchaseDate

                });

            return Ok(ticketsList);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<IEnumerable<TicketListModel>>> GetTicketByUser(string username)
        {
            var tickets = await _repository.Ticket.GetAll();

            var ticketsList = tickets
                .Where(x=> x.BookingNavigation.Username.Equals(username))
                .Select(x => new TicketListModel
                {
                    Seat = x.Seat,
                    Match = x.BookingNavigation.MatchNavigation,
                    Amount = x.BookingNavigation.Amount,
                    FirstName = x.BookingNavigation.FirstName,
                    LastName = x.BookingNavigation.LastName,
                    Username = x.BookingNavigation.Username,
                    Email = x.BookingNavigation.Email,
                    PurchaseDate = x.BookingNavigation.PurchaseDate

                });


            return Ok(ticketsList);
        }

        // GET: api/Tickets/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Ticket>> GetTicketById(int id)
        {
            var ticket = await _repository.Ticket.Get(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.TicketId)
            {
                return BadRequest();
            }

            await _repository.Ticket.Update(ticket);

            return NoContent();
        }

        // POST: api/Tickets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(TicketFormModel ticketModel)
        {
            var ticket = new Ticket
            {
                Seat = ticketModel.Seat,
                BookingNavigation = new Booking
                {
                    Amount = ticketModel.Amount,
                    PurchaseDate = ticketModel.PurchaseDate,
                    FirstName = ticketModel.FirstName,
                    LastName = ticketModel.LastName,
                    Email = ticketModel.Email,
                    Username = ticketModel.Username,
                    MatchId = ticketModel.MatchId
                }
            };

            await _repository.Ticket.Add(ticket);
            return CreatedAtAction("GetTicket", new { id = ticket.TicketId }, ticket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ticket>> DeleteTicket(int id)
        {
            var ticket = await _repository.Ticket.Delete(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }
    }
}
