using Microsoft.EntityFrameworkCore;
using EFCoreTest.Data.Entities;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreTest.Data
{
    public class OwnersContext : DbContext
    {
        public OwnersContext() : base()
        {
            Database.Migrate();
        }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Car> Cars { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(z => z.Owner)
                .WithMany(z => z.Cars)
                .HasForeignKey(z => z.OwnerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Car>().Property(z => z.Brand).IsRequired();
            modelBuilder.Entity<Car>().Property(z => z.Model).IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EFConnectionString"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}