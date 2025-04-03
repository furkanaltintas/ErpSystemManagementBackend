using ErpSystemManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErpSystemManagement.Persistence.Configurations;

class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
{
    public void Configure(EntityTypeBuilder<StockMovement> builder)
    {
        builder.Property(s => s.NumberOfEntries).HasColumnType("decimal(7,2)");
        builder.Property(s => s.NumberOfOutpus).HasColumnType("decimal(7,2)");
        builder.Property(s => s.Price).HasColumnType("money");

        builder
            .HasOne(r => r.Product)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }
}
