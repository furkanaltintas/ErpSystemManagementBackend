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
            #region Sipariş bulma ve detay silme
            Order? order = await orderRepository.Where(o => o.Id == request.Id).Include(o => o.Details).FirstOrDefaultAsync();
            if (order is null) return DomainResult<string>.Failed("Sipariş bulunamadı");
            orderDetailRepository.DeleteRange(order.Details);
            #endregion

            #region Sipariş detay ekleme
            List<OrderDetail> orderDetails = request.Details.Select(od => new OrderDetail
            {
                OrderId = order.Id,
                ProductId = od.ProductId,
                Price = od.Price,
                Quantity = od.Quantity
            }).ToList();
            await orderDetailRepository.AddRangeAsync(orderDetails, cancellationToken);
            #endregion

            #region Sipariş kaydetme
            mapper.Map(request, order);
            orderRepository.Update(order);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return DomainResult.Success("Sipariş başarıyla güncellendi");
            #endregion
        }
        catch (DbUpdateException)
        {
            return DomainResult<string>.Failed("Sipariş güncellenirken bir hata oluştu. Lütfen tekrar deneyin.");
        }
        catch (Exception) // Genel hata yakalama
        {
            return DomainResult<string>.Failed("Beklenmedik bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
        }
    }
}