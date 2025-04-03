using DomainResults.Common;
using ErpSystemManagement.Application.Features.Productions.Commands.DeleteProduction;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ErpSystemManagement.Application.Features.Productions.Handlers.DeleteProduction
{
    class DeleteProductionCommandHandler(
        IProductionRepository productionRepository,
        IStockMovementRepository stockMovementRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductionCommand, IDomainResult<string>>
    {
        public async Task<IDomainResult<string>> Handle(DeleteProductionCommand request, CancellationToken cancellationToken)
        {
            Production? production = await productionRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);
            if (production is null) return DomainResult<string>.Failed("Üretim bulunamadı");

            List<StockMovement> stockMovements = await stockMovementRepository.Where(s => s.ProductionId == production.Id).ToListAsync(cancellationToken);
            stockMovementRepository.DeleteRange(stockMovements);

            productionRepository.Delete(production);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return DomainResult<string>.Success("Üretim başarıyla silindi");
        }
    }
}