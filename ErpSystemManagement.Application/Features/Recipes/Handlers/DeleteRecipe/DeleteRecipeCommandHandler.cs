using DomainResults.Common;
using ErpSystemManagement.Application.Features.Recipes.Commands.DeleteRecipe;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;

namespace ErpSystemManagement.Application.Features.Recipes.Handlers.DeleteRecipe
{
    class DeleteRecipeCommandHandler(
        IRecipeRepository recipeRepository,
        IUnitOfWork unitOfWork): IRequestHandler<DeleteRecipeCommand, IDomainResult<string>>
    {
        public async Task<IDomainResult<string>> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            Recipe? recipe = await recipeRepository.GetByExpressionAsync(r => r.Id == request.Id, cancellationToken);
            if (recipe is null) return DomainResult<string>.Failed("Sistemde böyle bir reçete bulunmamaktadır");

            recipeRepository.Delete(recipe);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return DomainResult<string>.Success("Reçete başarıyla silindi");
        }
    }
}