using DomainResults.Common;
using ErpSystemManagement.Application.Features.Products.Commands.DeleteProduct;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;

namespace ErpSystemManagement.Application.Features.Products.Handlers.DeleteProduct;

class DeleteProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteProductCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        Product? product = await productRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (product is null) return DomainResult<string>.Failed("Ürün kaydı bulunamadı");

        productRepository.Delete(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return DomainResult<string>.Success("Ürün başarıyla silindi");
    }
}