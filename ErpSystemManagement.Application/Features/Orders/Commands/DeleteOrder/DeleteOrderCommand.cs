using DomainResults.Common;
using MediatR;

namespace ErpSystemManagement.Application.Features.Orders.Commands.DeleteOrder;
public record DeleteOrderCommand(Guid Id) : IRequest<IDomainResult<string>>;