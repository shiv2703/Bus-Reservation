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
    public class FeedbacksController : ControllerBase
    {
        private readonly busReservationcontext _context;

        public FeedbacksController(busReservationcontext context)
        {
            _context = context;
        }

        // GET: api/Feedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> Getfeedback()
        {
            return await _context.feedback.ToListAsync();
        }

        // GET: api/Feedbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedback(int id)
        {
            var feedback = await _context.feedback.FindAsync(id);

            if (feedback == null)
            {
                return NotFound();
            }

            return feedback;
        }

        // PUT: api/Feedbacks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedback(int id, Feedback feedback)
        {
            if (id != feedback.feedBackId)
            {
                return BadRequest();
            }

            _context.Entry(feedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(id))
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

        // POST: api/Feedbacks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Feedback>> PostFeedback(Feedback feedback)
        {
            _context.feedback.Add(feedback);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedback", new { id = feedback.feedBackId }, feedback);
        }

        // DELETE: api/Feedbacks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Feedback>> DeleteFeedback(int id)
        {
            var feedback = await _context.feedback.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }

            _context.feedback.Remove(feedback);
            await _context.SaveChangesAsync();

            return feedback;
        }

        private bool FeedbackExists(int id)
        {
            return _context.feedback.Any(e => e.feedBackId == id);
        }
    }
}
