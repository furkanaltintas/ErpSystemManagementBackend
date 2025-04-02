using AutoMapper;
using DomainResults.Common;
using ErpSystemManagement.Application.Features.Orders.Commands.UpdateOrder;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ErpSystemManagement.Application.Features.Orders.Handlers.UpdateOrder;

class UpdateOrderCommandHandler(
    IOrderRepository orderRepository,
    IOrderDetailRepository orderDetailRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateOrderCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Order? order = await orderRepository.Where(o => o.Id == request.Id).Include(o => o.Details).FirstOrDefaultAsync();
            if (order is null) return DomainResult<string>.Failed("Sipariş bulunamadı");

            orderDetailRepository.DeleteRange(order.Details);

            mapper.Map(request, order);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return DomainResult.Success("Sipariş başarıyla güncellendi");
        }
        catch (DbUpdateException ex)
        {
            return DomainResult<string>.Failed("Sipariş güncellenirken bir hata oluştu. Lütfen tekrar deneyin.");
        }
        catch (Exception ex) // Genel hata yakalama
        {
            return DomainResult<string>.Failed("Beklenmedik bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
        }
    }
}