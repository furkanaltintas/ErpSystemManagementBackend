using DomainResults.Common;
using ErpSystemManagement.Application.Features.Depots.Queries.GetAllDepots;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ErpSystemManagement.Application.Features.Depots.Handlers.GetAllDepots;

class GetAllDepotsQueryHandler(
    IDepotRepository depotRepository) : IRequestHandler<GetAllDepotsQuery, IDomainResult<IEnumerable<Depot>>>
{
    public async Task<IDomainResult<IEnumerable<Depot>>> Handle(GetAllDepotsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Depot> depots = await depotRepository.GetAll().OrderBy(d => d.Name).ToListAsync();
        return DomainResult.Success(depots);
    }
}