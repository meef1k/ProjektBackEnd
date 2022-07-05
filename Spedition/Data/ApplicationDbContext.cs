using Microsoft.EntityFrameworkCore;
using Spedition.Models;

namespace Spedition.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Truck> Truck { get; set; }
        public DbSet<Trailer> Trailer { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Speditions> Spedition { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Speditions>(x =>
            {
                x.HasOne(a => a.Driver).WithMany(b => b.Speditionsa).HasForeignKey(c => c.DriverId).OnDelete(DeleteBehavior.NoAction);
                x.HasOne(a => a.Truck).WithMany(b => b.Speditionsa).HasForeignKey(c => c.TruckId).OnDelete(DeleteBehavior.NoAction);
                x.HasOne(a => a.Trailer).WithMany(b => b.Speditionsa).HasForeignKey(c => c.TrailerId).OnDelete(DeleteBehavior.NoAction);
            });

        }
    }
}