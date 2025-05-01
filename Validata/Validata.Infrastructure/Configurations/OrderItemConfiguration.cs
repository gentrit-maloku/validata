using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Validata.Domain.Entities;

namespace Validata.Infrastructure.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Quantity)
                .IsRequired();

            builder.HasOne(i => i.Product)
                .WithMany()
                .HasForeignKey(i => i.ProductId);

            builder.Ignore(i => i.TotalPrice);
        }
    }
}
