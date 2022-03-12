using AvonaleApiVendas.Models;
using Microsoft.EntityFrameworkCore;

namespace AvonaleApiVendas.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<CreditCard> CreditCard { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Purchase> Purchase { get; set; }



    }
}
