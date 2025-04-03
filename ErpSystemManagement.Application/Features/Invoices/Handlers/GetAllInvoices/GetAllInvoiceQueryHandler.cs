using DomainResults.Common;
using ErpSystemManagement.Application.Features.Invoices.Queries.GetAllInvoices;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Enums;
using ErpSystemManagement.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ErpSystemManagement.Application.Features.Invoices.Handlers.GetAllInvoices;

class GetAllInvoiceQueryHandler(IInvoiceRepository invoiceRepository) : IRequestHandler<GetAllInvoiceQuery, IDomainResult<List<Invoice>>>
{
    public async Task<IDomainResult<List<Invoice>>> Handle(GetAllInvoiceQuery request, CancellationToken cancellationToken)
    {
        List<Invoice> invoices = await invoiceRepository
            .Where(i => i.InvoiceType == ((InvoiceTypeEnum)request.Type).ToString())
            .Include(i => i.Customer)
            .Include(i => i.Details)
                .ThenInclude(id => id.Product)
            .Include(i => i.Details)
                .ThenInclude(id => id.Depot)
            .OrderBy(i => i.Date)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return DomainResult.Success(invoices);
    }
}