using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using ErpSystemManagement.Persistence.Context;
using GenericRepository;

namespace ErpSystemManagement.Persistence.Repositories;

public class ProductionRepository : Repository<Production, AppDbContext>, IProductionRepository
{
    public ProductionRepository(AppDbContext context) : base(context) { }
}