using DomainResults.Common;
using MediatR;

namespace ErpSystemManagement.Application.Features.RecipeDetails.Commands.UpdateRecipeDetail;

public record UpdateRecipeDetailCommand(
    Guid Id,
    Guid ProductId,
    decimal Quantity) : IRequest<IDomainResult<string>>;