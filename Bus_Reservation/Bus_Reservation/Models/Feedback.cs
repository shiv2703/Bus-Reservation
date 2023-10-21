using System.ComponentModel.DataAnnotations;

namespace Bus_Reservation.Models
{
    public class Feedback
    {
        [Key]
        public int feedBackId { get; set; }

        [Required(ErrorMessage = "Please share your Experience")]
        [Display(Name = "User Expereince")]
        public string feedBackMessage { get; set; }
    }
}
