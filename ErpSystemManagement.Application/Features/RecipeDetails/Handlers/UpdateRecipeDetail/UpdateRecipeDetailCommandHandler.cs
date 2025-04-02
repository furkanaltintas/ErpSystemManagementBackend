using AutoMapper;
using DomainResults.Common;
using ErpSystemManagement.Application.Features.RecipeDetails.Commands.UpdateRecipeDetail;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ErpSystemManagement.Application.Features.RecipeDetails.Handlers.UpdateRecipeDetail;

class UpdateRecipeDetailCommandHandler(
    IRecipeDetailRepository recipeDetailRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateRecipeDetailCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(UpdateRecipeDetailCommand request, CancellationToken cancellationToken)
    {
        RecipeDetail? recipeDetail = await recipeDetailRepository.GetByExpressionWithTrackingAsync(r => r.Id == request.Id, cancellationToken);
        if (recipeDetail is null) return DomainResult<string>.Failed("Reçetede bu ürün bulunamadı");

        RecipeDetail? oldRecipeDetail = await recipeDetailRepository
            .Where(r =>
            r.Id != request.Id &&
            r.ProductId == request.ProductId &&
            r.RecipeId == recipeDetail.RecipeId)
            .FirstOrDefaultAsync(cancellationToken);

        if(oldRecipeDetail is not null)
        {
            recipeDetailRepository.Delete(recipeDetail);
            oldRecipeDetail.Quantity += request.Quantity;
            recipeDetailRepository.Update(oldRecipeDetail);
        }
        else
        {
            mapper.Map(request, recipeDetail);
        }

        await unitOfWork.SaveChangesAsync();
        return DomainResult<string>.Success("Reçetedeki ürün başarıyla güncellendi");
    }
}

