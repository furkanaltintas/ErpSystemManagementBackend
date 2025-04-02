using DomainResults.Common;
using MediatR;

namespace ErpSystemManagement.Application.Features.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(
        Guid Id) : IRequest<IDomainResult<string>>;
}
