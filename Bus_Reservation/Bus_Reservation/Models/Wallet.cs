using System.ComponentModel.DataAnnotations;

namespace Bus_Reservation.Models
{
    public class Wallet
    {
        [Key]
        public int wallletId { get; set; }

        [Display(Name = "Amount")]
        public int amountRemaining { get; set; }

        public int UserId { get; set; }
    }
}
