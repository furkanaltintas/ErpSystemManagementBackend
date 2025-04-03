using ErpSystemManagement.Domain.Abstractions;

namespace ErpSystemManagement.Domain.Entities;

public class Order : BaseEntity
{
    public Guid CustomerId { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public DateOnly DeliveryDate { get; set; }
    public string Status { get; set; } = "Bekliyor";

    public Customer? Customer { get; set; }
    public ICollection<OrderDetail>? Details { get; set; }
}