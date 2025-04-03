using ErpSystemManagement.Application.Features.Productions.Commands.CreateProduction;
using ErpSystemManagement.Application.Features.Productions.Commands.DeleteProduction;
using ErpSystemManagement.Application.Features.Productions.Queries.GetAllProductions;
using ErpSystemManagement.WebApi.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ErpSystemManagement.WebApi.Controllers;

public class ProductionsController : ApiController
{
    public ProductionsController(IMediator mediator) : base(mediator) { }


    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllProductionsQuery getAllProductionsQuery, CancellationToken cancellationToken) =>
        await HandleRequest(getAllProductionsQuery, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> Create(CreateProductionCommand createProductionCommand, CancellationToken cancellationToken) =>
        await HandleRequest(createProductionCommand, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> Delete(DeleteProductionCommand deleteProductionCommand, CancellationToken cancellationToken) =>
        await HandleRequest(deleteProductionCommand, cancellationToken);
}