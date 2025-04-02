using DomainResults.Common;
using ErpSystemManagement.Application.Features.Customers.Commands.DeleteCustomer;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;

namespace ErpSystemManagement.Application.Features.Customers.Handlers.DeleteCustomer;

class DeleteCustomerCommandHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteCustomerCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer? customer = await customerRepository.GetByExpressionAsync(c => c.Id == request.Id, cancellationToken);
        if (customer is null) return DomainResult<string>.Failed("Müşteri bulunamadı");

        customerRepository.Delete(customer);
        await unitOfWork.SaveChangesAsync();
        return DomainResult<string>.Success("Müşteri başarıyla silindi");
    }
}