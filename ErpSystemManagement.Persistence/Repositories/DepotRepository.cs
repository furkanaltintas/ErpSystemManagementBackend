using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using ErpSystemManagement.Persistence.Context;
using GenericRepository;

namespace ErpSystemManagement.Persistence.Repositories;

public class DepotRepository : Repository<Depot, AppDbContext>, IDepotRepository
{
    public DepotRepository(AppDbContext context) : base(context) { }
}