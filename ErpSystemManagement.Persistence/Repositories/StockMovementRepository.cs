using ErpSystemManagement.Domain.Repositories;
using ErpSystemManagement.Persistence.Context;
using ErpSystemManagement.Domain.Entities;
using GenericRepository;

namespace ErpSystemManagement.Persistence.Repositories;

public class StockMovementRepository : Repository<StockMovement, AppDbContext>, IStockMovementRepository
{
    public StockMovementRepository(AppDbContext context) : base(context) { }
}