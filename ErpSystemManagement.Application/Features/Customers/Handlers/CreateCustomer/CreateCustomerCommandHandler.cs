using AutoMapper;
using DomainResults.Common;
using ErpSystemManagement.Application.Features.Customers.Commands.CreateCustomer;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;

namespace ErpSystemManagement.Application.Features.Customers.Handlers.CreateCustomer;

class CreateCustomerCommandHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateCustomerCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        bool isTaxNumberExists = await customerRepository.AnyAsync(c => c.TaxNumber == request.TaxNumber);
        if (isTaxNumberExists) return DomainResult<string>.Failed("Vergi numarası daha önce kaydedilmiş");

        Customer customer = mapper.Map<Customer>(request);
        customerRepository.Add(customer);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return DomainResult<string>.Success("Müşteri kaydı başarıyla tamamlandı");
    }
}