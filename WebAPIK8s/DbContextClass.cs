using Microsoft.EntityFrameworkCore;

namespace WebAPIK8s
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options) 
        {
        }
        public DbSet<CustomerDetails> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerDetails>().HasKey(x => x.CustomerID);
        }
    }
}
