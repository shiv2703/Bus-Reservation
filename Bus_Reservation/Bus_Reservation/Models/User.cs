using System;
using System.ComponentModel.DataAnnotations;

namespace Bus_Reservation.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = " User First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "User Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        //[MinLength(6, ErrorMessage = "Email is too Short"), MaxLength(50, ErrorMessage = "Email is too long")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Password is too Short"), MaxLength(25, ErrorMessage = "Password is too long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Re Enter your Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password you enetered is incorrect")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Age is Required")]
        [Display(Name = "Age")]
        [Range(18, 120, ErrorMessage = "Minimum 18 year old should book a Bus")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Contact is Required")]
        [Display(Name = "Contact")]
        [StringLength(10)]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Date of Birth is Required")]
        [Display(Name = "Date of Birth")]
        public DateTime dob { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

    }
}
