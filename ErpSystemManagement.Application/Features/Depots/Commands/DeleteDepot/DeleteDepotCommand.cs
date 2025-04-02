using DomainResults.Common;
using MediatR;

namespace ErpSystemManagement.Application.Features.Depots.Commands.DeleteDepot;

public record DeleteDepotCommand(Guid Id) : IRequest<IDomainResult<string>>;
