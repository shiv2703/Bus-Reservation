using System.ComponentModel.DataAnnotations;

namespace Bus_Reservation.Models
{
    public class Station
    {
        [Key]
        public int stationId { get; set; }

        [Required(ErrorMessage = "Station Name")]
        [Display(Name = "Station Name")]
        public string stationName { get; set; }
    }
}
