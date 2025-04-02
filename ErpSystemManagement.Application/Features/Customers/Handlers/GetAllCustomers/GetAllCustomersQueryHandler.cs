using DomainResults.Common;
using ErpSystemManagement.Application.Features.Customers.Queries.GetAllCustomers;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ErpSystemManagement.Application.Features.Customers.Handlers.GetAllCustomers;

class GetAllCustomersQueryHandler(ICustomerRepository customerRepository) : IRequestHandler<GetAllCustomersQuery, IDomainResult<IEnumerable<Customer>>>
{
    public async Task<IDomainResult<IEnumerable<Customer>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Customer> customers = await customerRepository.GetAll().OrderBy(c => c.Name).ToListAsync();
        return DomainResult.Success(customers);
    }
}