using DomainResults.Common;
using MediatR;

namespace ErpSystemManagement.Application.Features.RecipeDetails.Commands.DeleteRecipeDetail;

public record DeleteRecipeDetailCommand(Guid Id) : IRequest<IDomainResult<string>>;