using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using ErpSystemManagement.Persistence.Context;
using GenericRepository;

namespace ErpSystemManagement.Persistence.Repositories;

public class InvoiceDetailRepository : Repository<InvoiceDetail, AppDbContext>, IInvoiceDetailRepository
{
    public InvoiceDetailRepository(AppDbContext context) : base(context) { }
}