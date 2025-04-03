using DomainResults.Common;
using ErpSystemManagement.Application.Features.Products.Queries.GetAllProducts;
using ErpSystemManagement.Application.Features.Products.Responses.GetAllProducts;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ErpSystemManagement.Application.Features.Products.Handlers.GetAllProducts;

public class GetAllProductsQueryHandler(
    IProductRepository productRepository,
    IStockMovementRepository stockMovementRepository) : IRequestHandler<GetAllProductsQuery, IDomainResult<IEnumerable<GetAllProductsQueryResponse>>>
{
    public async Task<IDomainResult<IEnumerable<GetAllProductsQueryResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> products = await productRepository.GetAll().OrderBy(p => p.Name).ToListAsync(cancellationToken);

        IEnumerable<GetAllProductsQueryResponse> getAllProductsQueryResponses = products.Select(p => new GetAllProductsQueryResponse
        {
            Id = p.Id,
            Name = p.Name,
            Type = p.Type,
            Stock = 0
        }).ToList();

        foreach (GetAllProductsQueryResponse product in getAllProductsQueryResponses)
        {
            decimal stock = await stockMovementRepository
                .Where(s => s.ProductId == product.Id)
                .SumAsync(s => s.NumberOfEntries - s.NumberOfOutpus);

            product.Stock = stock;
        }

        return DomainResult.Success(getAllProductsQueryResponses);
    }
}