using DomainResults.Common;
using ErpSystemManagement.Application.Features.Orders.Queries.GetAllOrders;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ErpSystemManagement.Application.Features.Orders.Handlers.GetAllOrders;

class GetAllOrdersQueryHandler(IOrderRepository orderRepository) : IRequestHandler<GetAllOrdersQuery, IDomainResult<List<Order>>>
{
    public async Task<IDomainResult<List<Order>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        List<Order>? orders = await orderRepository
            .GetAll()
            .Include(o => o.Customer)
            .Include(o => o.Details)
            .ThenInclude(o => o.Product)
            .OrderByDescending(o => o.Date)
            .ToListAsync(cancellationToken);

        return DomainResult.Success(orders);
    }
}
