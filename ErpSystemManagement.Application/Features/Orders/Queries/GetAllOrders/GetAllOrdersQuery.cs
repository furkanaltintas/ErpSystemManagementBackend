using DomainResults.Common;
using ErpSystemManagement.Domain.Entities;
using MediatR;

namespace ErpSystemManagement.Application.Features.Orders.Queries.GetAllOrders;

public record GetAllOrdersQuery() : IRequest<IDomainResult<List<Order>>>;
