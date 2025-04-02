using AutoMapper;
using DomainResults.Common;
using ErpSystemManagement.Application.Features.Products.Commands.UpdateProduct;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;

namespace ErpSystemManagement.Application.Features.Products.Handlers.UpdateProduct;

class UpdateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateProductCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product? product = await productRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);
        if (product is null) return DomainResult<string>.Failed("Ürün kaydı bulunamadı");

        mapper.Map(request, product);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return DomainResult<string>.Success("Ürün başarıyla güncellendi");
    }
}