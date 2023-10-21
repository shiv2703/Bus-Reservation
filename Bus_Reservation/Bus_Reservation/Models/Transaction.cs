using System;

namespace Bus_Reservation.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public int amount { get; set; }

        public int BookingId { get; set; }

        public DateTime trasactionDateTime { get; set; }


    }
}
