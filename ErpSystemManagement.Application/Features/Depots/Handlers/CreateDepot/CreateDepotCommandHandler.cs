using AutoMapper;
using DomainResults.Common;
using ErpSystemManagement.Application.Features.Depots.Commands.CreateDepot;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;

namespace ErpSystemManagement.Application.Features.Depots.Handlers.CreateDepot;

class CreateDepotCommandHandler(
    IDepotRepository depotRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateDepotCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(CreateDepotCommand request, CancellationToken cancellationToken)
    {
        Depot depot = mapper.Map<Depot>(request);
        depotRepository.Add(depot);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return DomainResult<string>.Success("Depo kaydı başarıyla tamamlandı");
    }
}