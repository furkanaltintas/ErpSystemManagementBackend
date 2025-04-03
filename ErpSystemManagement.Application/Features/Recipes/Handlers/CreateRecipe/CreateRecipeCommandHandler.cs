using DomainResults.Common;
using ErpSystemManagement.Application.Features.Recipes.Commands.CreateRecipe;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;

namespace ErpSystemManagement.Application.Features.Recipes.Handlers.CreateRecipe;

class CreateRecipeCommandHandler(
    IRecipeRepository recipeRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateRecipeCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        bool isRecipeExists = await recipeRepository.AnyAsync(r => r.ProductId == request.ProductId);
        if (isRecipeExists) return DomainResult.Failed<string>("Bu ürüne ait reçete daha önce oluşturulmuş");

        Recipe recipe = new()
        {
            ProductId = request.ProductId,
            Details = request.Details.Select(r => new RecipeDetail()
            {
                ProductId = r.ProductId,
                Quantity = r.Quantity
            }).ToList()
        };

        await recipeRepository.AddAsync(recipe);
        await unitOfWork.SaveChangesAsync();

        return DomainResult<string>.Success("Reçete kaydı başarıyla tamamlandı");
    }
}