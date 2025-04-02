using ErpSystemManagement.Domain.Abstractions;

namespace ErpSystemManagement.Domain.Entities;

public class RecipeDetail : BaseEntity
{
    public Guid RecipeId { get; set; }
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }

    public Product? Product { get; set; }
}