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
        public DbSet<Speditions> Speditions { get; set; }
    }
}