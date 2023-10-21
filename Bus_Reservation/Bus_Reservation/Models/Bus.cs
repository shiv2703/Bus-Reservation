using System.ComponentModel.DataAnnotations;

namespace Bus_Reservation.Models
{
    public class Bus
    {
        [Key]
        public int busId { get; set; }

        [Required(ErrorMessage = " Bus Name is required")]
        [Display(Name = "Bus Name")]
        public string busName { get; set; }

        [Required(ErrorMessage = "Bus Type is Required")]
        [Display(Name = "Bus Type")]
        public string busType { get; set; }

        [Required]
        public int isActive { get; set; }

        [Required]
        public int TotalSeats { get; set; }
    }
}
