using ErpSystemManagement.Domain.Abstractions;

namespace ErpSystemManagement.Domain.Entities;

public class Recipe : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public List<RecipeDetail>? Details { get; set; }
}