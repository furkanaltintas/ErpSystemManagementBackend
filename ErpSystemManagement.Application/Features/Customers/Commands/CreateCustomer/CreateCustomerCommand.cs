using DomainResults.Common;
using MediatR;

namespace ErpSystemManagement.Application.Features.Customers.Commands.CreateCustomer;

public record CreateCustomerCommand(
    string Name,
    string TaxDepartment,
    string TaxNumber,
    string City,
    string Town,
    string FullAddress) : IRequest<IDomainResult<string>>;
