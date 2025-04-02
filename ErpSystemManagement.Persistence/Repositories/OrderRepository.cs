using Azure.Core;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using ErpSystemManagement.Persistence.Context;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace ErpSystemManagement.Persistence.Repositories;

class OrderRepository : Repository<Order, AppDbContext>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<string?> GetLastOrderNumberAsync(CancellationToken cancellationToken)
    {
        return await GetAllWithTracking().OrderByDescending(o => o.Id).Select(o => o.OrderNumber).FirstOrDefaultAsync(cancellationToken);
    }
}


        //Order? lastOrder = await orderRepository
        //    .Where(o => o.Date.Year == request.Date.Year)
        //    .OrderByDescending(o => o.OrderNumber)
        //    .FirstOrDefaultAsync(cancellationToken);