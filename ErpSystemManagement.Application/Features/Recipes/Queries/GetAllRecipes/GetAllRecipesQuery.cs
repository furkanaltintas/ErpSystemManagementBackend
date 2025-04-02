using DomainResults.Common;
using ErpSystemManagement.Domain.Entities;
using MediatR;

namespace ErpSystemManagement.Application.Features.Recipes.Queries.GetAllRecipes;

public record GetAllRecipesQuery() : IRequest<IDomainResult<IEnumerable<Recipe>>>;