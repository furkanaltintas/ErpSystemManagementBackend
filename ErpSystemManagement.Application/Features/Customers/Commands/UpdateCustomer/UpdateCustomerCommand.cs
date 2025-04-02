using DomainResults.Common;
using MediatR;

namespace ErpSystemManagement.Application.Features.Customers.Commands.UpdateCustomer;

public record UpdateCustomerCommand(
    Guid Id,
    string Name,
    string TaxDepartment,
    string TaxNumber,
    string City,
    string Town,
    string FullAddress) : IRequest<IDomainResult<string>>;
