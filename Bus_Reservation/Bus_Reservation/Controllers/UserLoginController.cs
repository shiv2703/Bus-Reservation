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
    public class UserLoginController : ControllerBase
    {
        public busReservationcontext _context { get; }

        public UserLoginController(busReservationcontext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(UserLogin user)
        {
            var data = _context.Users.Where(s => s.Email.Equals(user.UserName) && s.Password.Equals(user.Password));
            if (data.Count() > 0)
            {
                return Ok(data);
            }
            else
                return NotFound();
        }

        [HttpGet]
        public IEnumerable<User> getuserdetails()
        {
            return (_context.Users.ToList());
        }

        [HttpPost]
        public ActionResult postuser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("Wallet")]
         public IEnumerable<Wallet> GetWalletDetails(Wallet wallet)
        {
            var walletDetails = (from wd in _context.wallet
                                join ud in _context.Users
                                on wd.UserId equals ud.UserId

                                select new Wallet
                                {
                                    wallletId = wd.wallletId,
                                    amountRemaining = wd.amountRemaining,
                                    UserId = ud.UserId,
                                }).ToList();
            return walletDetails;
        }

        [HttpPut]
        [Route("Wallet")]

        public ActionResult PutWallet()
        {

            return Ok();
        }

        [HttpGet]
        [Route("wallet")]
        public async Task<ActionResult<IEnumerable<Wallet>>> GetWallet()
        {
            return await _context.wallet.ToListAsync();
        }



    }
}
