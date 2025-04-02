using ErpSystemManagement.Application.Features.Depots.Commands.CreateDepot;
using ErpSystemManagement.Application.Features.Depots.Commands.DeleteDepot;
using ErpSystemManagement.Application.Features.Depots.Commands.UpdateDepot;
using ErpSystemManagement.Application.Features.Depots.Queries.GetAllDepots;
using ErpSystemManagement.WebApi.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ErpSystemManagement.WebApi.Controllers;

public class DepotsController : ApiController
{
    public DepotsController(IMediator mediator) : base(mediator) { }


    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllDepotsQuery getAllDepotsQuery, CancellationToken cancellationToken)
    {
        return await HandleRequest(getAllDepotsQuery, cancellationToken);
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateDepotCommand createDepotCommand, CancellationToken cancellationToken)
    {
        return await HandleRequest(createDepotCommand, cancellationToken);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateDepotCommand updateDepotCommand, CancellationToken cancellationToken)
    {
        return await HandleRequest(updateDepotCommand, cancellationToken);
    }


    [HttpPost]
    public async Task<IActionResult> Delete(DeleteDepotCommand deleteDepotCommand, CancellationToken cancellationToken)
    {
        return await HandleRequest(deleteDepotCommand, cancellationToken);
    }
}
