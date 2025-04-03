using DomainResults.Common;
using MediatR;

namespace ErpSystemManagement.Application.Features.Orders.Commands.RequirementsPlanningByOrderId;

public record RequirementsPlanningByOrderIdCommand(Guid OrderId) : IRequest<IDomainResult<RequirementsPlanningByOrderIdCommandResponse>>;