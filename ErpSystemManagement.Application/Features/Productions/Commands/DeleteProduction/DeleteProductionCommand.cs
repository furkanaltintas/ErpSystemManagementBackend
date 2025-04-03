using DomainResults.Common;
using MediatR;

namespace ErpSystemManagement.Application.Features.Productions.Commands.DeleteProduction;

public record DeleteProductionCommand(Guid Id) : IRequest<IDomainResult<string>>;