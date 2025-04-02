using DomainResults.Common;
using ErpSystemManagement.Domain.Entities;
using MediatR;

namespace ErpSystemManagement.Application.Features.Products.Queries.GetAllProducts;

public record GetAllProductsQuery() : IRequest<IDomainResult<IEnumerable<Product>>>;