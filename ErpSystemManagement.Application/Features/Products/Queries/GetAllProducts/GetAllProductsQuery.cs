using DomainResults.Common;
using ErpSystemManagement.Domain.Entities;
using MediatR;

namespace ErpSystemManagement.Application.Features.Products.Queries.GetAllProducts;

public record GetAllProductsQuery() : IRequest<IDomainResult<IEnumerable<GetAllProductsQueryResponse>>>;

public record GetAllProductsQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Type { get; set; } = 1; // Bekliyor
    public decimal Stock { get; set; }
}