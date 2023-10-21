using Bus_Reservation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Bus_Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        public busReservationcontext _context { get; } 
        public FeedbackController(busReservationcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Feedback> Get()
        {
            return _context.feedback.ToList();
        }

        [HttpPost]
        public ActionResult PostFeedback(Feedback feed)
        {
            _context.feedback.Add(feed);
            _context.SaveChanges();
            return Ok();

        }
    }
}
