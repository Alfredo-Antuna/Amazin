using Microsoft.EntityFrameworkCore;

namespace WebManufacturer
{
    public class Database : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public Database(DbContextOptions<Database> options) : base(options) { }
    }
}