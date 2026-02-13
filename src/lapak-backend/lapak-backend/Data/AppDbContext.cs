using Microsoft.EntityFrameworkCore;
using lapak_backend.Models; 

namespace lapak_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Room)
                .WithMany() 
                .HasForeignKey(b => b.RoomId);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.Building)
                .WithMany()
                .HasForeignKey(r => r.BuildingId);
        }
    }
}