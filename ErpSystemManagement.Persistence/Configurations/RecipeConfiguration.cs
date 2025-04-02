using ErpSystemManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErpSystemManagement.Persistence.Configurations;

class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder
            .HasOne(r => r.Product)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction); // Recipe silindiği zaman, Product değeri silinmeyecek
    }
}