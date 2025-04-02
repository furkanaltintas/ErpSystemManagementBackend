using AutoMapper;
using DomainResults.Common;
using ErpSystemManagement.Application.Features.Orders.Commands.CreateOrder;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Entities.ValueObjects;
using ErpSystemManagement.Domain.Repositories;
using GenericRepository;
using MediatR;

namespace ErpSystemManagement.Application.Features.Orders.Handlers.CreateOrder;

class CreateOrderCommandHandler(
    IOrderRepository orderRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    OrderNumberGenerator orderNumberGenerator) : IRequestHandler<CreateOrderCommand, IDomainResult<string>>
{
    public async Task<IDomainResult<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Order? order = mapper.Map<Order>(request);
        order.OrderNumber = await orderNumberGenerator.GenerateNextOrderNumberAsync(cancellationToken);

        await orderRepository.AddAsync(order, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return DomainResult.Success("Sipariş başarıyla oluşturuldu");
    }
}