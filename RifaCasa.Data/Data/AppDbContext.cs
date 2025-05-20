using Microsoft.EntityFrameworkCore;
using RifaCasa.Models;

namespace RifaCasa.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Raffle> Raffles { get; set; }
        public DbSet<Buyer> Buyers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            modelBuider.Entity<Buyer>().HasKey(c => c.Phone);
            base.OnModelCreating(modelBuider);
        }
    }
}
