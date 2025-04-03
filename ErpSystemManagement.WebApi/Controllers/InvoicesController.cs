using ErpSystemManagement.Application.Features.Invoices.Commands.CreateInvoice;
using ErpSystemManagement.Application.Features.Invoices.Commands.DeleteInvoice;
using ErpSystemManagement.Application.Features.Invoices.Commands.UpdateInvoice;
using ErpSystemManagement.Application.Features.Invoices.Queries.GetAllInvoices;
using ErpSystemManagement.WebApi.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ErpSystemManagement.WebApi.Controllers;

public class InvoicesController : ApiController
{
    public InvoicesController(IMediator mediator) : base(mediator) { }


    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllInvoiceQuery getAllInvoiceQuery, CancellationToken cancellationToken) =>
        await HandleRequest(getAllInvoiceQuery, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> Create(CreateInvoiceCommand createInvoiceCommand, CancellationToken cancellationToken) =>
        await HandleRequest(createInvoiceCommand, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> Update(UpdateInvoiceCommand updateInvoiceCommand, CancellationToken cancellationToken) =>
        await HandleRequest(updateInvoiceCommand, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> Delete(DeleteInvoiceCommand deleteInvoiceCommand, CancellationToken cancellationToken) =>
        await HandleRequest(deleteInvoiceCommand, cancellationToken);
}