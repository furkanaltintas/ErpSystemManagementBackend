using DomainResults.Common;
using MediatR;

namespace ErpSystemManagement.Application.Features.Depots.Commands.UpdateDepot;

public record UpdateDepotCommand(
    Guid Id,
    string Name,
    string City,
    string Town,
    string FullAddress) : IRequest<IDomainResult<string>>;