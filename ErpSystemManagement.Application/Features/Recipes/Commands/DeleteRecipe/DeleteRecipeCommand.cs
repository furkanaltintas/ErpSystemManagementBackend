using DomainResults.Common;
using MediatR;

namespace ErpSystemManagement.Application.Features.Recipes.Commands.DeleteRecipe;

public record DeleteRecipeCommand(Guid Id) : IRequest<IDomainResult<string>>;