using DomainResults.Common;
using MediatR;

namespace ErpSystemManagement.Application.Features.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(
        Guid Id,
        string Name,
        int Type) : IRequest<IDomainResult<string>>;
}
