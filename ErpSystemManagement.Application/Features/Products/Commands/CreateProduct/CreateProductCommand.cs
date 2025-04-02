using DomainResults.Common;
using MediatR;

namespace ErpSystemManagement.Application.Features.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    int Type) : IRequest<IDomainResult<string>>;
