using DomainResults.Common;
using ErpSystemManagement.Application.Dtos;
using MediatR;

namespace ErpSystemManagement.Application.Features.Orders.Commands.CreateOrder;

public record CreateOrderCommand(
    Guid CustomerId,
    DateOnly Date,
    DateOnly DeliveryDate,
    List<OrderDetailDto> Details) : IRequest<IDomainResult<string>>;