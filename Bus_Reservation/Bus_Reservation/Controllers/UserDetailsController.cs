using Bus_Reservation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bus_Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private busReservationcontext _context;

        public UserDetailsController(busReservationcontext context)
        {
            _context = context;
        }
    }
}
