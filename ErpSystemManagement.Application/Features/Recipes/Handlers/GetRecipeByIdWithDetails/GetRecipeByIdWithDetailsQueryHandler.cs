using DomainResults.Common;
using ErpSystemManagement.Application.Features.Recipes.Queries.GetRecipeByIdWithDetails;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ErpSystemManagement.Application.Features.Recipes.Handlers.GetRecipeByIdWithDetails;

class GetRecipeByIdWithDetailsQueryHandler(IRecipeRepository recipeRepository) : IRequestHandler<GetRecipeByIdWithDetailsQuery, IDomainResult<Recipe>>
{
    public async Task<IDomainResult<Recipe>> Handle(GetRecipeByIdWithDetailsQuery request, CancellationToken cancellationToken)
    {
        Recipe? recipe = await recipeRepository
            .Where(r => r.Id == request.RecipeId)
            .Include(r => r.Product)
            .Include(r => r.Details!.OrderBy(r => r.Product!.Name))
            .ThenInclude(r => r.Product)
            .FirstOrDefaultAsync(cancellationToken);

        if (recipe is null) return DomainResult<Recipe>.Failed("Ürüne ait reçete bulunamadı");

        return DomainResult.Success(recipe);
    }
}
