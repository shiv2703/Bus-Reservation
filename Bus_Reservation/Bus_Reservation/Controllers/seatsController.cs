using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bus_Reservation.Models;

namespace Bus_Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class seatsController : ControllerBase
    {
        private readonly busReservationcontext _context;

        public seatsController(busReservationcontext context)
        {
            _context = context;
        }

        // GET: api/seats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> Getbooking_details()
        {
            return await (from sd in _context.bookingdetail
                          join td in _context.bus_trip
                          on sd.tripId equals td.tripId
                          join ud in _context.Users
                          on sd.Userid equals ud.UserId
                          join bd in _context.bus_details
                          on td.busId equals bd.busId

                          select new Booking
                          {
                              BookingId=sd.BookingId,
                              cost=sd.cost,
                              tripId=sd.tripId,
                              Userid=sd.Userid,
                              seatNumber=sd.seatNumber,
                              Busname=bd.busName,
                              busType=bd.busType,
                              fromdate=td.fromDatetime,
                              todate=td.toDatetime,
                              source=td.source,
                              destination=td.destination,
                              firstname=ud.FirstName,
                              lastname=ud.LastName
                          }).ToListAsync();
        }

        // GET: api/seats/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Booking>> GetBooking(int id)
        {
            var booking = _context.bookingdetail.Where(c => c.tripId.Equals(id));

            if (booking == null)
            {
                return Ok();
            }

            return Ok(booking);
        }

        // PUT: api/seats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/seats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            _context.bookingdetail.Add(booking);
            await _context.SaveChangesAsync();
            var book = await _context.bookingdetail.FindAsync(booking.BookingId);
            return Ok(book);
        }

        // DELETE: api/seats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Booking>> DeleteBooking(int id)
        {
            var booking = await _context.bookingdetail.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.bookingdetail.Remove(booking);
            await _context.SaveChangesAsync();

            return booking;
        }

        private bool BookingExists(int id)
        {
            return _context.bookingdetail.Any(e => e.BookingId == id);
        }

        [HttpPost]
        [Route("transaction")]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction transactions)
        {
            _context.transaction.Add(transactions);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("transaction")]
        public async Task<ActionResult<IEnumerable<Transaction>>> Gettransactions()
        {
            return await _context.transaction.ToListAsync();
        }

    }
}
