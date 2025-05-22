using Microsoft.EntityFrameworkCore;
using RifaCasa.Data.Models;

namespace RifaCasa.Data.EFCore
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Raffle> Raffles { get; set; }
        public DbSet<Buyer> Buyers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            modelBuider.Entity<Buyer>().HasKey(c => c.Phone);
            base.OnModelCreating(modelBuider);
        }
    }
}
