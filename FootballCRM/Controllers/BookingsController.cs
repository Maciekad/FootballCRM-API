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
    public class BookingsController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public BookingsController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingsListModel>>> GetBookings()
        {
            var bookings = await _repository.Booking.GetAll();

            var bookingsList = bookings
                .Select(x => new BookingsListModel
                {
                    Amount = x.Amount,
                    PurchaseDate = x.PurchaseDate,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Username = x.Username,
                    HomeTeam = x.MatchNavigation.HomeTeamNavigation.Name,
                    AwayTeam = x.MatchNavigation.AwayTeamNavigation.Name
                });

            return Ok(bookingsList);
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingsListModel>> GetBooking(int id)
        {
            var booking = await _repository.Booking.Get(id);

            if (booking == null)
            {
                return NotFound();
            }

            var bookingModel = new BookingsListModel
            {
                Amount = booking.Amount,
                PurchaseDate = booking.PurchaseDate,
                FirstName = booking.FirstName,
                LastName = booking.LastName,
                Email = booking.Email,
                Username = booking.Username,
                HomeTeam = booking.MatchNavigation.HomeTeamNavigation.Name,
                AwayTeam = booking.MatchNavigation.AwayTeamNavigation.Name
            };

            return bookingModel;
        }

        // PUT: api/Bookings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.BookingId)
            {
                return BadRequest();
            }

            await _repository.Booking.Update(booking);
     
            return NoContent();
        }

        // POST: api/Bookings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            await _repository.Booking.Add(booking);
            return CreatedAtAction("GetBooking", new { id = booking.BookingId }, booking);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Booking>> DeleteBooking(int id)
        {
            var booking = await _repository.Booking.Delete(id);
            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }
    }
}
