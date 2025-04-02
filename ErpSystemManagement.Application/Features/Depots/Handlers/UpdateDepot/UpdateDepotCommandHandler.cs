using AutoMapper;
using DomainResults.Common;
using ErpSystemManagement.Application.Features.Depots.Commands.UpdateDepot;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;

namespace ErpSystemManagement.Application.Features.Depots.Handlers.UpdateDepot;

class UpdateDepotCommandHandler(
    IDepotRepository depotRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateDepotCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(UpdateDepotCommand request, CancellationToken cancellationToken)
    {
        Depot? depot = await depotRepository.GetByExpressionWithTrackingAsync(d => d.Id == request.Id, cancellationToken);
        if (depot == null) return DomainResult<string>.Failed("Depo kaydı bulunamadı");

        mapper.Map(request, depot);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return DomainResult<string>.Success("Depo başarıyla güncellendi");
    }
}
