using DomainResults.Common;
using ErpSystemManagement.Domain.Entities;
using MediatR;

namespace ErpSystemManagement.Application.Features.Recipes.Queries.GetRecipeByIdWithDetails;

public record GetRecipeByIdWithDetailsQuery(Guid RecipeId) : IRequest<IDomainResult<Recipe>>;