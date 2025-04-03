using DomainResults.Common;
using ErpSystemManagement.Application.Features.Orders.Responses.RequirementsPlanningByOrderId;
using MediatR;

namespace ErpSystemManagement.Application.Features.Orders.Commands.RequirementsPlanningByOrderId;

public record RequirementsPlanningByOrderIdCommand(Guid OrderId) : IRequest<IDomainResult<RequirementsPlanningByOrderIdCommandResponse>>;