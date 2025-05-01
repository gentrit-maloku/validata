using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Validata.Domain.Entities;

namespace Validata.Infrastructure.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.PostalCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasMany(c => c.Orders)
                .WithOne()
                .HasForeignKey(o => o.CustomerId);
        }
    }
}
