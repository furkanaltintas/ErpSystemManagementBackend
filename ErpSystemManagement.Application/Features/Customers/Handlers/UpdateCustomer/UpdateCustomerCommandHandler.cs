using AutoMapper;
using DomainResults.Common;
using ErpSystemManagement.Application.Features.Customers.Commands.UpdateCustomer;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;

namespace ErpSystemManagement.Application.Features.Customers.Handlers.UpdateCustomer;

class UpdateCustomerCommandHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateCustomerCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer? customer = await customerRepository.GetByExpressionWithTrackingAsync(c => c.Id == request.Id, cancellationToken);
        if (customer is null) return DomainResult<string>.Failed("Müşteri bulunamadı");

        if (customer.TaxNumber != request.TaxNumber)
        {
            bool isTaxNumberExists = await customerRepository.AnyAsync(c => c.TaxNumber == request.TaxNumber);
            if (isTaxNumberExists) return DomainResult<string>.Failed("Vergi numarası daha önce kaydedilmiş");
        }

        mapper.Map(request, customer);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return DomainResult<string>.Success("Müşteri bilgileri başarıyla güncellendi");
    }
}