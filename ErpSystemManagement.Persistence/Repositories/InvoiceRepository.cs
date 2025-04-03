using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using ErpSystemManagement.Persistence.Context;
using GenericRepository;

namespace ErpSystemManagement.Persistence.Repositories;

public class InvoiceRepository : Repository<Invoice, AppDbContext>, IInvoiceRepository
{
    public InvoiceRepository(AppDbContext context) : base(context) { }
}