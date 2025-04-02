using DomainResults.Common;
using MediatR;

namespace ErpSystemManagement.Application.Features.Depots.Commands.CreateDepot;

public record CreateDepotCommand(
    string Name,
    string City,
    string Town,
    string FullAddress) : IRequest<IDomainResult<string>>;
