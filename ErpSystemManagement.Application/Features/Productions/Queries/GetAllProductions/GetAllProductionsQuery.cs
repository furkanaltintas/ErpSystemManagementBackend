using DomainResults.Common;
using ErpSystemManagement.Domain.Entities;
using MediatR;

namespace ErpSystemManagement.Application.Features.Productions.Queries.GetAllProductions;

public record GetAllProductionsQuery : IRequest<IDomainResult<List<Production>>>;
