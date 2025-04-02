using DomainResults.Common;
using ErpSystemManagement.Application.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ErpSystemManagement.Application.Features.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand(
    Guid Id,
    Guid CustomerId,
    DateTime Date,
    DateTime DeliveryDate,
    List<OrderDetailDto> Details) : IRequest<IDomainResult<string>>;