using ErpSystemManagement.Application.Features.Customers.Commands.CreateCustomer;
using ErpSystemManagement.Application.Features.Customers.Commands.DeleteCustomer;
using ErpSystemManagement.Application.Features.Customers.Commands.UpdateCustomer;
using ErpSystemManagement.Application.Features.Customers.Queries.GetAllCustomers;
using ErpSystemManagement.WebApi.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ErpSystemManagement.WebApi.Controllers;

public class CustomersController : ApiController
{
    public CustomersController(IMediator mediator) : base(mediator) { }


    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllCustomersQuery getAllCustomersQuery, CancellationToken cancellationToken)
    {
        return await HandleRequest(getAllCustomersQuery, cancellationToken);
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerCommand createCustomerCommand, CancellationToken cancellationToken)
    {
        return await HandleRequest(createCustomerCommand, cancellationToken);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateCustomerCommand updateCustomerCommand, CancellationToken cancellationToken)
    {
        return await HandleRequest(updateCustomerCommand, cancellationToken);
    }


    [HttpPost]
    public async Task<IActionResult> Delete(DeleteCustomerCommand deleteCustomerCommand, CancellationToken cancellationToken)
    {
        return await HandleRequest(deleteCustomerCommand, cancellationToken);
    }
}
