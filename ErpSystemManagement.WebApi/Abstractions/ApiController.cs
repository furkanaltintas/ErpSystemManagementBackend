using DomainResults.Common;
using ErpSystemManagement.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ErpSystemManagement.WebApi.Abstractions;

[Route("api/[controller]/[action]")]
[ApiController]
public class ApiController : ControllerBase
{
    protected readonly IMediator _mediator;

    public ApiController(IMediator mediator) { _mediator = mediator; }

    protected async Task<IActionResult> HandleRequest<T>(IRequest<IDomainResult<T>> request, CancellationToken cancellationToken) =>
        this.DomResult(await _mediator.Send(request, cancellationToken));

    protected async Task<IActionResult> HandleRequest<T>(IRequest<T> request, CancellationToken cancellationToken) =>
        this.Result(await _mediator.Send(request, cancellationToken));
}