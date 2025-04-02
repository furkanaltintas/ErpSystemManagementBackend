using DomainResults.Common;
using ErpSystemManagement.Domain.Entities;
using MediatR;

namespace ErpSystemManagement.Application.Features.Customers.Queries.GetAllCustomers;

public record GetAllCustomersQuery() : IRequest<IDomainResult<IEnumerable<Customer>>>;