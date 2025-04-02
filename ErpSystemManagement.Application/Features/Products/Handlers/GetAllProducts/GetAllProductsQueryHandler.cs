using DomainResults.Common;
using ErpSystemManagement.Application.Features.Products.Queries.GetAllProducts;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ErpSystemManagement.Application.Features.Products.Handlers.GetAllProducts;

public class GetAllProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, IDomainResult<IEnumerable<Product>>>
{
    public async Task<IDomainResult<IEnumerable<Product>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Product> products = await productRepository.GetAll().OrderBy(p => p.Name).ToListAsync(cancellationToken);
        return DomainResult.Success(products);
    }
}