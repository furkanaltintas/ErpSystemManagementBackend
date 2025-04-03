using ErpSystemManagement.Application.Features.Customers.Commands.CreateCustomer;
using ErpSystemManagement.Application.Features.Customers.Commands.DeleteCustomer;
using ErpSystemManagement.Application.Features.Customers.Commands.UpdateCustomer;
using ErpSystemManagement.Application.Features.Customers.Queries.GetAllCustomers;
using ErpSystemManagement.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ErpSystemManagement.WebApi.Controllers;

public class CustomersController : ApiController
{
    public CustomersController(IMediator mediator) : base(mediator) { }


    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllCustomersQuery getAllCustomersQuery, CancellationToken cancellationToken) =>
        await HandleRequest(getAllCustomersQuery, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerCommand createCustomerCommand, CancellationToken cancellationToken) =>
        await HandleRequest(createCustomerCommand, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> Update(UpdateCustomerCommand updateCustomerCommand, CancellationToken cancellationToken) =>
        await HandleRequest(updateCustomerCommand, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> Delete(DeleteCustomerCommand deleteCustomerCommand, CancellationToken cancellationToken) =>
        await HandleRequest(deleteCustomerCommand, cancellationToken);
}
