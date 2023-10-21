using System.ComponentModel.DataAnnotations;

namespace Bus_Reservation.Models
{
    public class Admin
    {

        [Key]
        public int AdminId { get; set; }

        [Required(ErrorMessage = "Admin User Name")]
        [Display(Name = "User Name")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "Admin Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Password is too Short"), MaxLength(25, ErrorMessage = "Password is too long")]
        public string AdminPassword { get; set; }
    }
}
