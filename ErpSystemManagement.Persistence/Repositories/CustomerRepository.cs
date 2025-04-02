using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using ErpSystemManagement.Persistence.Context;
using GenericRepository;

namespace ErpSystemManagement.Persistence.Repositories;

public class CustomerRepository : Repository<Customer, AppDbContext >, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context) { }
}