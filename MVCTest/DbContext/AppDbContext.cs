using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCTest.Models;

namespace MVCTest.DbContext
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
            modelBuilder.Entity<Passenger>()
            .HasIndex(u => u.BookReference)
            .IsUnique();  
            modelBuilder.Entity<Flight>()
            .HasIndex(u => u.FlightNumber)
            .IsUnique();
        }
        DbSet<Passenger> Passenger { get; set; }
        DbSet<Flight> Flight { get; set; }
    }
}
