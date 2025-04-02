using ErpSystemManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErpSystemManagement.Persistence.Configurations;

class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.Property(o => o.Price).HasColumnType("money");
        builder.Property(o => o.Quantity).HasColumnType("decimal(7,2)");

        builder
            .HasOne(o => o.Product)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }
}