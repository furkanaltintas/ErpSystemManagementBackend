using DomainResults.Common;
using MediatR;

namespace ErpSystemManagement.Application.Features.RecipeDetails.Commands.CreateRecipeDetail;

public record CreateRecipeDetailCommand(
    Guid RecipeId,
    Guid ProductId,
    decimal Quantity) : IRequest<IDomainResult<string>>;