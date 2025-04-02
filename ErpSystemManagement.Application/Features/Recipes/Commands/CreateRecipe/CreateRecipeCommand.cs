using DomainResults.Common;
using ErpSystemManagement.Application.Dtos;
using MediatR;

namespace ErpSystemManagement.Application.Features.Recipes.Commands.CreateRecipe;

public record CreateRecipeCommand(
    Guid ProductId,
    List<RecipeDetailDto> Details) : IRequest<IDomainResult<string>>;