using ErpSystemManagement.Domain.Entities;
using GenericRepository;

namespace ErpSystemManagement.Domain.Repositories;

public interface  IOrderRepository : IRepository<Order> 
{
    Task<string?> GetLastOrderNumberAsync(CancellationToken cancellationToken);
}
