using Microsoft.EntityFrameworkCore;

namespace WebStore
{
    public class Database : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages {get; set; }
        public DbSet<Order> Orders {get; set; }
        public DbSet <OrderDetail> OrderDetails {get; set; }
        public Database(DbContextOptions<Database> options) : base(options) { }
    }
}