using AutoMapper;
using DomainResults.Common;
using ErpSystemManagement.Application.Features.Invoices.Commands.CreateInvoice;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;

namespace ErpSystemManagement.Application.Features.Invoices.Handlers.CreateInvoice;

class CreateInvoiceCommandHandler(
    IInvoiceRepository invoiceRepository,
    IStockMovementRepository stockMovementRepository,
    IOrderRepository orderRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateInvoiceCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        Invoice? invoice = mapper.Map<Invoice>(request);

        if (invoice.Details is not null)
        {
            List<StockMovement> stockMovements = new();
            foreach (InvoiceDetail invoiceDetail in invoice.Details)
            {
                StockMovement stockMovement = new()
                {
                    InvoiceId = invoice.Id,
                    ProductId = invoiceDetail.ProductId,
                    DepotId = invoiceDetail.DepotId,
                    NumberOfEntries = request.InvoiceType == 1 ? invoiceDetail.Quantity : 0,
                    NumberOfOutpus = request.InvoiceType == 2 ? invoiceDetail.Quantity : 0,
                    Price = invoiceDetail.Price
                };

                stockMovements.Add(stockMovement);
            }

            await stockMovementRepository.AddRangeAsync(stockMovements, cancellationToken);
        }

        await invoiceRepository.AddAsync(invoice, cancellationToken);

        // Sipariş güncelleme
        if (request.OrderId is not null)
        {
            Order order = await orderRepository.GetByExpressionWithTrackingAsync(o => o.Id == request.OrderId, cancellationToken);
            if (order is not null) order.Status = "Completed";
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return DomainResult.Success("Fatura başarıyla oluşturuldu");
    }
}
