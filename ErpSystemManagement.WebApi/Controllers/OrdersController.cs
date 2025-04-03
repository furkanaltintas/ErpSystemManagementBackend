using ErpSystemManagement.Application.Features.Orders.Commands.RequirementsPlanningByOrderId;
using ErpSystemManagement.Application.Features.Orders.Commands.CreateOrder;
using ErpSystemManagement.Application.Features.Orders.Commands.DeleteOrder;
using ErpSystemManagement.Application.Features.Orders.Commands.UpdateOrder;
using ErpSystemManagement.Application.Features.Orders.Queries.GetAllOrders;
using ErpSystemManagement.WebApi.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ErpSystemManagement.WebApi.Controllers;

public class OrdersController : ApiController
{
    public OrdersController(IMediator mediator) : base(mediator) { }


    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllOrdersQuery getAllOrdersQuery, CancellationToken cancellationToken) =>
        await HandleRequest(getAllOrdersQuery, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommand createOrderCommand, CancellationToken cancellationToken) =>
        await HandleRequest(createOrderCommand, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> Update(UpdateOrderCommand updateOrderCommand, CancellationToken cancellationToken) =>
    await HandleRequest(updateOrderCommand, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> Delete(DeleteOrderCommand deleteOrderCommand, CancellationToken cancellationToken) =>
        await HandleRequest(deleteOrderCommand, cancellationToken);


    [HttpPost]
    public async Task<IActionResult> RequirementsPlanningByOrderId(RequirementsPlanningByOrderIdCommand requirementsPlanningByOrderIdCommand, CancellationToken cancellationToken) =>
        await HandleRequest(requirementsPlanningByOrderIdCommand, cancellationToken);
}