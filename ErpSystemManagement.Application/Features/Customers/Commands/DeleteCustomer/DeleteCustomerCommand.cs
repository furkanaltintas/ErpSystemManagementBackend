using DomainResults.Common;
using MediatR;

namespace ErpSystemManagement.Application.Features.Customers.Commands.DeleteCustomer;

public record DeleteCustomerCommand(Guid Id) : IRequest<IDomainResult<string>>;