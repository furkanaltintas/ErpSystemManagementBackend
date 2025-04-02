using DomainResults.Common;
using ErpSystemManagement.Domain.Entities;
using MediatR;

namespace ErpSystemManagement.Application.Features.Depots.Queries.GetAllDepots;

public record GetAllDepotsQuery() : IRequest<IDomainResult<IEnumerable<Depot>>>;