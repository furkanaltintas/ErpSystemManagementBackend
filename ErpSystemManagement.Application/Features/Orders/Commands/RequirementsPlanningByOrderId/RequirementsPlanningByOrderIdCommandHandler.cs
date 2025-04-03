using DomainResults.Common;
using ErpSystemManagement.Application.Dtos;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ErpSystemManagement.Application.Features.Orders.Commands.RequirementsPlanningByOrderId;

class RequirementsPlanningByOrderIdCommandHandler(
    IOrderRepository orderRepository,
    IStockMovementRepository stockMovementRepository,
    IRecipeRepository recipeRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<RequirementsPlanningByOrderIdCommand, IDomainResult<RequirementsPlanningByOrderIdCommandResponse>>
{
    public async Task<IDomainResult<RequirementsPlanningByOrderIdCommandResponse>> Handle(RequirementsPlanningByOrderIdCommand request, CancellationToken cancellationToken)
    {
        Order? order = await orderRepository
            .Where(o => o.Id == request.OrderId)
            .Include(o => o.Details)!
            .ThenInclude(od => od.Product)
            .FirstOrDefaultAsync(cancellationToken);

        if (order is null) return DomainResult<RequirementsPlanningByOrderIdCommandResponse>.Failed("Sipariş bulunamadı");

        List<RequirementProductDto> requiredProducts = await GetRequiredProducts(order, cancellationToken);

        order.Status = "İhtiyaç Planı Çalışıldı";
        orderRepository.Update(order);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return DomainResult.Success(new RequirementsPlanningByOrderIdCommandResponse(
            $"{order.OrderNumber} Nolu siparişin ihtiyaç planlaması",
            DateOnly.FromDateTime(DateTime.Now),
            requiredProducts
        ));
    }



    // Sipariş detaylarını kontrol ederek stok yetersizliği olan ürünleri belirler.
    private async Task<List<RequirementProductDto>> GetRequiredProducts(Order order, CancellationToken cancellationToken)
    {
        List<RequirementProductDto> neededProducts = new();

        foreach (var orderDetail in order.Details!)
        {
            decimal stock = await GetProductStock(orderDetail.Product!.Id, cancellationToken);
            if (stock < orderDetail.Quantity) neededProducts.Add(new RequirementProductDto(orderDetail.Product.Id, orderDetail.Product.Name, orderDetail.Quantity - stock));
        }

        List<RequirementProductDto> additionalRequirements = await GetRecipeRequirements(neededProducts, cancellationToken);
        return AggregateRequirements(additionalRequirements);
    }


    // Belirtilen ürünün stok miktarını hesaplar
    private async Task<decimal> GetProductStock(Guid productId, CancellationToken cancellationToken)
    {
        var stockMovements = await stockMovementRepository.Where(s => s.ProductId == productId).ToListAsync(cancellationToken);
        return stockMovements.Sum(s => s.NumberOfEntries) - stockMovements.Sum(s => s.NumberOfOutpus);
    }


    // Üretilmesi gereken ürünlerin reçetelerini alarak üretim için gereken ek ürünleri belirler
    private async Task<List<RequirementProductDto>> GetRecipeRequirements(List<RequirementProductDto> requiredProducts, CancellationToken cancellationToken)
    {
        List<RequirementProductDto> allRequirements = new();

        foreach (var item in requiredProducts)
        {
            Recipe? recipe = await recipeRepository
                .Where(r => r.ProductId == item.Id)
                .Include(r => r.Details)!
                .ThenInclude(rd => rd.Product)
                .FirstOrDefaultAsync(cancellationToken);

            if (recipe?.Details != null)
            {
                foreach (RecipeDetail recipeDetail in recipe.Details)
                {
                    decimal stock = await GetProductStock(recipeDetail.ProductId, cancellationToken);
                    if (stock < recipeDetail.Quantity) allRequirements.Add(new RequirementProductDto(recipeDetail.ProductId, recipeDetail.Product!.Name, recipeDetail.Quantity - stock));
                }
            }
        }
        return allRequirements;
    }


    // Aynı ürün için birden fazla ihtiyaç varsa bunları gruplayarak toplam ihtiyacı hesaplar
    private List<RequirementProductDto> AggregateRequirements(List<RequirementProductDto> requirements)
    {
        return requirements.GroupBy(r => r.Id)
            .Select(g => new RequirementProductDto(g.Key, g.First().Name, g.Sum(i => i.Quantity)))
            .ToList();
    }
}
