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
    public class BusesController : ControllerBase
    {
        private readonly busReservationcontext _context;

        public BusesController(busReservationcontext context)
        {
            _context = context;
        }

        // GET: api/Buses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bus>>> Getbus_details()
        {
            return await _context.bus_details.ToListAsync();
        }

        // GET: api/Buses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bus>> GetBus(int id)
        {
            var bus = await _context.bus_details.FindAsync(id);

            if (bus == null)
            {
                return NotFound();
            }

            return bus;
        }

        // PUT: api/Buses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBus(int id, Bus bus)
        {
            if (id != bus.busId)
            {
                return BadRequest();
            }

            _context.Entry(bus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusExists(id))
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

        // POST: api/Buses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bus>> PostBus(Bus bus)
        {
            _context.bus_details.Add(bus);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Buses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bus>> DeleteBus(int id)
        {
            var bus = await _context.bus_details.FindAsync(id);
            if (bus == null)
            {
                return NotFound();
            }

            _context.bus_details.Remove(bus);
            await _context.SaveChangesAsync();

            return bus;
        }

        private bool BusExists(int id)
        {
            return _context.bus_details.Any(e => e.busId == id);
        }
    }
}
