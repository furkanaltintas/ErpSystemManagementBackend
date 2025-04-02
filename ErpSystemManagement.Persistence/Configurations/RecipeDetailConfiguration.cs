using ErpSystemManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErpSystemManagement.Persistence.Configurations;

class RecipeDetailConfiguration : IEntityTypeConfiguration<RecipeDetail>
{
    public void Configure(EntityTypeBuilder<RecipeDetail> builder)
    {
        builder.Property(r => r.Quantity).HasColumnType("decimal(7,2)");
    }
}