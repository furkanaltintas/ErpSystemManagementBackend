using AutoMapper;
using DomainResults.Common;
using ErpSystemManagement.Application.Features.RecipeDetails.Commands.CreateRecipeDetail;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;

namespace ErpSystemManagement.Application.Features.RecipeDetails.Handlers.CreateRecipeDetail;

class CreateRecipeDetailCommandHandler(
    IRecipeDetailRepository recipeDetailRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateRecipeDetailCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(CreateRecipeDetailCommand request, CancellationToken cancellationToken)
    {
        RecipeDetail? recipeDetail = await recipeDetailRepository
            .GetByExpressionWithTrackingAsync(
            r => r.RecipeId == request.RecipeId &&
            r.ProductId == request.ProductId);

        if (recipeDetail is not null)
        {
            recipeDetail.Quantity += request.Quantity;
        }
        else
        {
            recipeDetail = mapper.Map<RecipeDetail>(request);
            await recipeDetailRepository.AddAsync(recipeDetail, cancellationToken);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return DomainResult.Success("Reçete ürün kaydı başarıyla tamamlandı");

    }
}

