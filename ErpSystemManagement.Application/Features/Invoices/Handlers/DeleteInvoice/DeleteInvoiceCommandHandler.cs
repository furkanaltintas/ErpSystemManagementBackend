using DomainResults.Common;
using ErpSystemManagement.Application.Features.Invoices.Commands.DeleteInvoice;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ErpSystemManagement.Application.Features.Invoices.Handlers.DeleteInvoice;

class DeleteInvoiceCommandHandler(
    IInvoiceRepository invoiceRepository,
    IStockMovementRepository stockMovementRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteInvoiceCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
    {
        Invoice? invoice = await invoiceRepository.GetByExpressionAsync(i => i.Id == request.Id, cancellationToken);
        if (invoice is null) return DomainResult.Failed<string>("Fatura bulunamadı");

        List<StockMovement> stockMovements = await stockMovementRepository.Where(s => s.InvoiceId == invoice.Id).ToListAsync(cancellationToken);
        stockMovementRepository.DeleteRange(stockMovements);

        invoiceRepository.Delete(invoice);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return DomainResult.Success("Fatura başarıyla silindi");
    }
}