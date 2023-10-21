using Bus_Reservation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Bus_Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {
        public busReservationcontext _context { get; }

        public AdminLoginController(busReservationcontext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var adm = _context.admin.Where(c => c.AdminName.Equals(admin.AdminName) && c.AdminPassword.Equals(admin.AdminPassword));
            if (adm.Count() > 0)
            {
                return Ok(adm);
            }
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmin()
        {
            return await _context.admin.ToListAsync();
        }

        [HttpGet]
        [Route("Bus")]

        public async Task<ActionResult<IEnumerable<Bus>>> GetBus()
        {
            return await _context.bus_details.ToListAsync();
        }

        [HttpPost]
        [Route("Bus")]
        public ActionResult PostBus(Bus bus)
        {
            _context.bus_details.Add(bus);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("BusTrip")]
        public async Task<ActionResult<IEnumerable<BusTrip>>> GetBusTrip()
        {
            //return await _context.bus_trip.ToListAsync();

            var busData = (from bt in _context.bus_trip
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
                           }).ToListAsync();
            return await busData;
        }

        [HttpGet("id")]
        [Route("BusTrip")]
        public ActionResult<BusTrip> GetBusTrip(int id)
        {
            //return await _context.bus_trip.ToListAsync();

            var busData =       (from bt in _context.bus_trip
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
            return Ok(busData);
        }

        [HttpPut("busTrip/{id}")]
        public async Task<IActionResult> PutRegistration(int id, BusTrip bustripdata)
        {
            if (id != bustripdata.tripId)
            {
                return BadRequest();
            }

            _context.Entry(bustripdata).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!busTripExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        private bool busTripExists(int id)
        {
            return _context.bus_trip.Any(bt => bt.tripId == id);
        }

        [HttpPost]
        [Route("busTrip")]
        public ActionResult<BusTrip> PostbusTrip(BusTrip bustripdata)
        {
            _context.bus_trip.Add(bustripdata);
            _context.SaveChanges();
            return Ok();
        }
    }
}
