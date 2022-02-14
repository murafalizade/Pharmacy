using Microsoft.EntityFrameworkCore;
using Pharmacy.Models;
namespace Pharmacy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<MedDepoInfo> MedDepoInfo { get; set; }
        public DbSet<Depo> Depo { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Type> Type { get; set; }

    }
}
