using AutoMapper;
using DomainResults.Common;
using ErpSystemManagement.Application.Dtos;
using ErpSystemManagement.Application.Features.Invoices.Commands.UpdateInvoice;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ErpSystemManagement.Application.Features.Invoices.Handlers.UpdateInvoice;

class UpdateInvoiceCommandHandler(
    IInvoiceRepository invoiceRepository,
    IInvoiceDetailRepository invoiceDetailRepository,
    IStockMovementRepository stockMovementRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateInvoiceCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
    {
        #region GetInvoice
        Invoice? invoice = await GetInvoiceAsync(request.Id, cancellationToken);
        if (invoice is null) return DomainResult.Failed<string>("Fatura bulunamadı");
        #endregion

        #region StockMovementDelete & UpdateInvoiceDetail 
        await DeleteStockMovementsAsync(invoice.Id, cancellationToken);
        await UpdateInvoiceDetailsAsync(invoice, request, cancellationToken);
        #endregion

        // Fatura bilgisini güncelle
        mapper.Map(request, invoice);

        #region StockMovement Add
        await AddStockMovementsAsync(invoice, request, cancellationToken);
        #endregion

        // Veritabanı değişikliklerini kaydet
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return DomainResult.Success("Fatura başarıyla güncelleştirildi");
    }



    private async Task<Invoice?> GetInvoiceAsync(Guid invoiceId, CancellationToken cancellationToken)
    {
        return await invoiceRepository
            .WhereWithTracking(i => i.Id == invoiceId)
            .Include(i => i.Details)
            .FirstOrDefaultAsync(cancellationToken);
    }

    private async Task DeleteStockMovementsAsync(Guid invoiceId, CancellationToken cancellationToken)
    {
        List<StockMovement> stockMovements = await stockMovementRepository
            .Where(s => s.InvoiceId == invoiceId)
            .ToListAsync(cancellationToken);

        if (stockMovements.Any())
            stockMovementRepository.DeleteRange(stockMovements);
    }

    private async Task UpdateInvoiceDetailsAsync(Invoice invoice, UpdateInvoiceCommand request, CancellationToken cancellationToken)
    {
        // Mevcut fatura detaylarını sil
        if (invoice.Details!.Any())
            invoiceDetailRepository.DeleteRange(invoice.Details);

        // Yeni fatura detaylarını oluştur
        invoice.Details = request.Details.Select(i => new InvoiceDetail
        {
            InvoiceId = invoice.Id,
            DepotId = i.DepotId,
            ProductId = i.ProductId,
            Price = i.Price,
            Quantity = i.Quantity
        }).ToList();

        // Yeni fatura detaylarını ekle
        await invoiceDetailRepository.AddRangeAsync(invoice.Details, cancellationToken);
    }

    private async Task AddStockMovementsAsync(Invoice invoice, UpdateInvoiceCommand request, CancellationToken cancellationToken)
    {
        List<StockMovement> newStockMovements = new();
        foreach (InvoiceDetailDto invoiceDetailDto in request.Details)
        {
            StockMovement stockMovement = new()
            {
                InvoiceId = invoice.Id,
                ProductId = invoiceDetailDto.ProductId,
                DepotId = invoiceDetailDto.DepotId,
                NumberOfEntries = request.InvoiceType == 1 ? invoiceDetailDto.Quantity : 0,
                NumberOfOutpus = request.InvoiceType == 2 ? invoiceDetailDto.Quantity : 0,
                Price = invoiceDetailDto.Price
            };

            newStockMovements.Add(stockMovement);
        }

        if (newStockMovements.Any())
            await stockMovementRepository.AddRangeAsync(newStockMovements, cancellationToken);
    }
}
