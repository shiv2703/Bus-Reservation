using Bus_Reservation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bus_Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public busReservationcontext _context { get; }

        public BookingController(busReservationcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetBookings()
        {
            var bookings = _context.bookingdetail.ToList();
            return Ok(bookings);
        }
        [HttpGet("{id}")]

        public ActionResult<IEnumerable<BusTrip>> GetBooking(int id)
        {
            var booking = (from bt in _context.bus_trip
                           join busOwner in _context.bus_details
                           on bt.busId equals busOwner.busId

                           select new BusTrip
                           {
                               tripId = bt.tripId,
                               busId = bt.busId,
                               source = bt.source,
                               destination = bt.destination,
                               fromDatetime = bt.fromDatetime,
                               toDatetime = bt.toDatetime,
                               availableSeats = bt.availableSeats,
                               isActive = bt.isActive,
                               Busname = busOwner.busName,
                               BusType = busOwner.busType,
                               Cost = bt.Cost,
                               Totalseats = busOwner.TotalSeats
                           }).Where(c => c.tripId.Equals(id));
            return Ok(booking);
        }

        [HttpPost]
        public ActionResult<BusTrip> PostbusTrip(BusTrip bustripdata)
        {
            var data = (from bt in _context.bus_trip
                        join busOwner in _context.bus_details
                        on bt.busId equals busOwner.busId

                        select new BusTrip
                        {
                            tripId = bt.tripId,
                            busId = bt.busId,
                            source = bt.source,
                            destination = bt.destination,
                            fromDatetime = bt.fromDatetime,
                            toDatetime = bt.toDatetime,
                            availableSeats = bt.availableSeats,
                            isActive = bt.isActive,
                            Busname = busOwner.busName,
                            BusType = busOwner.busType,
                            Cost = bt.Cost,
                            Totalseats = busOwner.TotalSeats
                        }).Where(c => c.source.Equals(bustripdata.source) && c.destination.Equals(bustripdata.destination) && c.fromDatetime.Equals(bustripdata.fromDatetime));

            if (data.Count() > 0)
            {
                return Ok(data);
            }
            else
                return NotFound();
        }




        [HttpGet("id")]
        [Route("seats")]
        public async Task<ActionResult<Booking>> GetBookingbyid(int id)
        {
            var bus = await _context.bookingdetail.FindAsync(id);

            if (bus == null)
            {
                return Ok();
            }

            return bus;
        }
    }
}