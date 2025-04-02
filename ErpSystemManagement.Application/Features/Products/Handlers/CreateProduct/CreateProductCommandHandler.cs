using AutoMapper;
using DomainResults.Common;
using ErpSystemManagement.Application.Features.Products.Commands.CreateProduct;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;

namespace ErpSystemManagement.Application.Features.Products.Handlers.CreateProduct
{
    class CreateProductCommandHandler(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper) : IRequestHandler<CreateProductCommand, IDomainResult<string>>
    {
        public async Task<IDomainResult<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Boolean isNameExists = await productRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
            if (isNameExists) return DomainResult<string>.Failed("Ürün adı daha önce kullanılmış");

            Product product = mapper.Map<Product>(request);
            await productRepository.AddAsync(product, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return DomainResult<string>.Success("Ürün kaydı başarıyla tamamlandı");
        }
    }
}