using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using ErpSystemManagement.Persistence.Context;
using GenericRepository;

namespace ErpSystemManagement.Persistence.Repositories;

public class ProductRepository : Repository<Product, AppDbContext>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context) { }
}