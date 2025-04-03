using DomainResults.Common;
using ErpSystemManagement.Application.Features.Recipes.Queries.GetAllRecipes;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ErpSystemManagement.Application.Features.Recipes.Handlers.GetAllRecipes;

class GetAllRecipesQueryHandler(
    IRecipeRepository recipeRepository) : IRequestHandler<GetAllRecipesQuery, IDomainResult<IEnumerable<Recipe>>>
{
    public async Task<IDomainResult<IEnumerable<Recipe>>> Handle(GetAllRecipesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Recipe> recipes = await recipeRepository
            .GetAll()
            .Include(r => r.Product)
            .OrderBy(r => r.Product!.Name)
            .ToListAsync(cancellationToken);
        return DomainResult.Success(recipes);
    }
}