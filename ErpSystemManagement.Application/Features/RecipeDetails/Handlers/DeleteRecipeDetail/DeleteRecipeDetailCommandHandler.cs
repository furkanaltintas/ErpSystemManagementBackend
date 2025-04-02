using DomainResults.Common;
using ErpSystemManagement.Application.Features.RecipeDetails.Commands.DeleteRecipeDetail;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;

namespace ErpSystemManagement.Application.Features.RecipeDetails.Handlers.DeleteRecipeDetail;

class DeleteRecipeDetailCommandHandler(
    IRecipeDetailRepository recipeDetailRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteRecipeDetailCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(DeleteRecipeDetailCommand request, CancellationToken cancellationToken)
    {
        RecipeDetail? recipeDetail = await recipeDetailRepository.GetByExpressionAsync(r => r.Id == request.Id, cancellationToken);
        if (recipeDetail is null) return DomainResult<string>.Failed("Reçetede bu ürün bulunamadı");
        
        recipeDetailRepository.Delete(recipeDetail);
        await unitOfWork.SaveChangesAsync();
        return DomainResult<string>.Success("Ürün reçeteden başarıyla silindi");
    }
}
