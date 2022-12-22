using BookingPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingPlatform.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<Admin> Admins{ get; set; }
    }
}
