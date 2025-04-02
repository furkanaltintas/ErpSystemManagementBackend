using DomainResults.Common;
using ErpSystemManagement.Application.Features.Orders.Commands.DeleteOrder;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;

namespace ErpSystemManagement.Application.Features.Orders.Handlers.DeleteOrder;

class DeleteOrderCommandHandler(
    IOrderRepository orderRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteOrderCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        Order? order = await orderRepository.GetByExpressionAsync(o => o.Id == request.Id, cancellationToken);
        if (order is null) return DomainResult<string>.Failed("Sipariş bulunamadı");

        orderRepository.Delete(order);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return DomainResult.Success("Sipariş başarıyla silindi");
    }
}