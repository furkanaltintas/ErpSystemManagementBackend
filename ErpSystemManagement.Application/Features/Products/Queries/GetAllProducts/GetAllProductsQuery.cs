using DomainResults.Common;
using ErpSystemManagement.Application.Features.Products.Responses.GetAllProducts;
using MediatR;

namespace ErpSystemManagement.Application.Features.Products.Queries.GetAllProducts;

public record GetAllProductsQuery() : IRequest<IDomainResult<IEnumerable<GetAllProductsQueryResponse>>>;