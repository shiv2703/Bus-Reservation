using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bus_Reservation.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required(ErrorMessage = "cost is required")]
        [Display(Name = "cost")]
        public int cost { get; set; }

        public int Userid { get; set; }

        public int tripId { get; set; }

        public string seatNumber { get; set; }

        [NotMapped]
        public string busType { get; set; }

        [NotMapped]
        public string Busname { get; set; }
        [NotMapped]
        public string source { get; set; }
        [NotMapped]
        public string destination { get; set; }

        [NotMapped]
        public DateTime fromdate { get; set; }
        [NotMapped]
        public DateTime todate { get; set; }
        [NotMapped]
        public string firstname { get; set; }
        [NotMapped]
        public string lastname { get; set; }


    }
}
