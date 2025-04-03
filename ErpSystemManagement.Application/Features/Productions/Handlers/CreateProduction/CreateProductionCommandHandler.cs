using AutoMapper;
using DomainResults.Common;
using ErpSystemManagement.Application.Features.Productions.Commands.CreateProduction;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ErpSystemManagement.Application.Features.Productions.Handlers.CreateProduction;

class CreateProductionCommandHandler(
    IProductionRepository productionRepository,
    IRecipeRepository recipeRepository,
    IStockMovementRepository stockMovementRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateProductionCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(CreateProductionCommand request, CancellationToken cancellationToken)
    {
        Production production = mapper.Map<Production>(request);
        List<StockMovement> newMoments = new();

        Recipe? recipe = await recipeRepository
            .Where(r => r.ProductId == request.ProductId)
            .Include(r => r.Details)!
            .ThenInclude(rd => rd.Product)
            .FirstOrDefaultAsync(cancellationToken);

        if (recipe is not null && recipe.Details is not null)
        {
            List<RecipeDetail>? details = recipe.Details;
            foreach (RecipeDetail detail in details)
            {
                List<StockMovement> stockMovements = await stockMovementRepository.Where(s => s.ProductId == detail.ProductId).ToListAsync();

                List<Guid> depotIds = stockMovements.GroupBy(s => s.DepotId).Select(s => s.Key).ToList();

                decimal stock = stockMovements.Sum(s => s.NumberOfEntries) - stockMovements.Sum(s => s.NumberOfOutpus);

                if (detail.Quantity > stock) return DomainResult<string>.Failed(detail.Product!.Name + " ürününden üretim için yeterli miktarda yok. Eksik miktar: " + (detail.Quantity - stock));

                foreach (Guid depotId in depotIds)
                {
                    if (detail.Quantity <= 0) break;

                    decimal quantity = stockMovements.Where(s => s.DepotId == depotId).Sum(s => s.NumberOfEntries - s.NumberOfOutpus);
                    decimal totalAmount = stockMovements.Where(s => s.DepotId == depotId && s.NumberOfEntries > 0).Sum(s => s.Price * s.NumberOfEntries);
                    decimal totalEntriesQuantity = stockMovements.Where(s => s.DepotId == depotId && s.NumberOfEntries > 0).Sum(S => S.NumberOfEntries);

                    decimal price = totalAmount / totalEntriesQuantity;

                    StockMovement stockMovement = new()
                    {
                        ProductionId = production.Id,
                        ProductId = detail.ProductId,
                        DepotId = depotId,
                        Price = price
                    };

                    if (detail.Quantity <= quantity)
                    {
                        stockMovement.NumberOfOutpus = detail.Quantity;
                    }
                    else
                    {
                        stockMovement.NumberOfOutpus = quantity;
                    }

                    detail.Quantity -= quantity;

                    newMoments.Add(stockMovement);
                }
            }
        }

        await stockMovementRepository.AddRangeAsync(newMoments, cancellationToken);
        await productionRepository.AddAsync(production, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return DomainResult.Success("Ürün başarıyla üretildi");
    }
}
