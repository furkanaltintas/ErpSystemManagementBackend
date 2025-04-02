using ErpSystemManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErpSystemManagement.Persistence.Configurations;

public class DepotConfiguration : IEntityTypeConfiguration<Depot>
{
    public void Configure(EntityTypeBuilder<Depot> builder)
    {
        builder.Property(d => d.Name).HasColumnType("varchar(50)");
        builder.Property(d => d.City).HasColumnType("varchar(50)");
        builder.Property(d => d.Town).HasColumnType("varchar(50)");
        builder.Property(d => d.FullAddress).HasColumnType("varchar(250)");
    }
}
