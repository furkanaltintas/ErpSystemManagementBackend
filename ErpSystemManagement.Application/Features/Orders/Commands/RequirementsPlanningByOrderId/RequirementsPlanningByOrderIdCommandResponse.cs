using ErpSystemManagement.Application.Dtos;

namespace ErpSystemManagement.Application.Features.Orders.Commands.RequirementsPlanningByOrderId;

public record RequirementsPlanningByOrderIdCommandResponse(
    string Title,
    DateOnly Date,
    List<RequirementProductDto> Products);
