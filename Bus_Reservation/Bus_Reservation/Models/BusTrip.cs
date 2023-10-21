using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bus_Reservation.Models
{
    public class BusTrip
    {
        [Key]
        public int tripId { get; set; }

        public int busId {get; set;}

        [Required]
        public string source { get; set;}

        [Required]
        public string destination { get; set;}

        [Required]
        public DateTime fromDatetime { get; set; }

        [Required]
        public DateTime toDatetime { get; set; }

        [Required]
        public int availableSeats { get; set; }

        [Required]
        public int isActive { get; set; }

        [NotMapped]
        public string Busname { get; set; }

        [NotMapped]
        public string BusType { get; set; }

        [Required]
        public int Cost { get; set; }

        [NotMapped]
        public int Totalseats { get; set; }

    }
}
