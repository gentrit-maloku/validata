using Microsoft.EntityFrameworkCore;
using Validata.Domain.Entities;

namespace Validata.Infrastructure
{
    public class ValidataDbContext : DbContext
    {
        public ValidataDbContext(DbContextOptions<ValidataDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ValidataDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
