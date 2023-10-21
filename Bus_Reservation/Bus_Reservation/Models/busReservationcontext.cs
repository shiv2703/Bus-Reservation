using Microsoft.EntityFrameworkCore;

namespace Bus_Reservation.Models
{
    public class busReservationcontext:DbContext
    {
        public busReservationcontext(DbContextOptions<busReservationcontext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Feedback> feedback {get; set; }
        public DbSet<Admin> admin { get; set; }
        public DbSet<Bus> bus_details { get; set; }
        public DbSet<Booking> bookingdetail { get; set; }
        public DbSet<Station> station { get; set; }
        public DbSet<Transaction> transaction { get; set; }
        public DbSet<Wallet> wallet { get; set; }
        public DbSet<BusTrip> bus_trip { get; set; }

    }
}
