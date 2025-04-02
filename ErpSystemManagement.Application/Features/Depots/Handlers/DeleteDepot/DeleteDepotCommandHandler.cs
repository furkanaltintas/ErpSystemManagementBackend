using DomainResults.Common;
using ErpSystemManagement.Application.Features.Depots.Commands.DeleteDepot;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;

namespace ErpSystemManagement.Application.Features.Depots.Handlers.DeleteDepot;

class DeleteDepotCommandHandler(
    IDepotRepository depotRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteDepotCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(DeleteDepotCommand request, CancellationToken cancellationToken)
    {
        Depot? depot = await depotRepository.GetByExpressionAsync(d => d.Id == request.Id, cancellationToken);
        if (depot is null) return DomainResult<string>.Failed("Depo bulunamadı");

        depotRepository.Delete(depot);
        await unitOfWork.SaveChangesAsync();
        return DomainResult<string>.Success("Depo başarıyla silindi");
    }
}