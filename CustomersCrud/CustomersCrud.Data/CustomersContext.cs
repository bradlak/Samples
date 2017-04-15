using CustomersCrud.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomersCrud.Data
{
    public class CustomersContext : DbContext
    {
        public CustomersContext(DbContextOptions<CustomersContext> options) 
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
