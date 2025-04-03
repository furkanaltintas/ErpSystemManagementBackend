using DomainResults.Common;
using MediatR;

namespace ErpSystemManagement.Application.Features.Productions.Commands.CreateProduction;

public record CreateProductionCommand(
    Guid ProductId,
    Guid DepotId,
    decimal Quantity) : IRequest<IDomainResult<string>>;