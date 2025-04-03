namespace ErpSystemManagement.Application.Features.Products.Responses.GetAllProducts;

public record GetAllProductsQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Type { get; set; } = 1; // Bekliyor
    public decimal Stock { get; set; }
}