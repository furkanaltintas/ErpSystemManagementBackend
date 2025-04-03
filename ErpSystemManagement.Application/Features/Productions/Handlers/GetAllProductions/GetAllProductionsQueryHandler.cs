using DomainResults.Common;
using ErpSystemManagement.Application.Features.Productions.Queries.GetAllProductions;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ErpSystemManagement.Application.Features.Productions.Handlers.GetAllProductions;

class GetAllProductionsQueryHandler(IProductionRepository productionRepository) : IRequestHandler<GetAllProductionsQuery, IDomainResult<List<Production>>>
{
    public async Task<IDomainResult<List<Production>>> Handle(GetAllProductionsQuery request, CancellationToken cancellationToken)
    {
        List<Production> productions = await productionRepository
            .GetAll()
            .Include(p => p.Product)
            .Include(p => p.Depot)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync(cancellationToken);
        return DomainResult.Success(productions);
    }
}