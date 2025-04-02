using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using ErpSystemManagement.Persistence.Context;
using GenericRepository;

namespace ErpSystemManagement.Persistence.Repositories
{
    class OrderDetailRepository : Repository<OrderDetail, AppDbContext>, IOrderDetailRepository
    {
        public OrderDetailRepository(AppDbContext context) : base(context)
        {
        }
    }
}
