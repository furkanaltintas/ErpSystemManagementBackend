using AutoMapper;
using ErpSystemManagement.Application.Features.Orders.Commands.CreateOrder;
using ErpSystemManagement.Application.Features.Orders.Commands.UpdateOrder;
using ErpSystemManagement.Domain.Entities;

namespace ErpSystemManagement.Application.Features.Orders.Profiles;

class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<CreateOrderCommand, Order>()
            .ForMember(member => member.Details, options => options.MapFrom(source => source.Details.Select(o => new OrderDetail
            {
                Price = o.Price,
                ProductId = o.ProductId,
                Quantity = o.Quantity
            })));

        CreateMap<UpdateOrderCommand, Order>()
            .ForMember(member => member.Details, options => options.Ignore()) // Detay kısmını mapleme
            .ReverseMap();
    }
}