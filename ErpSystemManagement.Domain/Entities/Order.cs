using ErpSystemManagement.Domain.Abstractions;

namespace ErpSystemManagement.Domain.Entities;

public class Order : BaseEntity
{
    public Guid CustomerId { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string Status { get; set; } = "Pending";

    public Customer? Customer { get; set; }
    public ICollection<OrderDetail>? Details { get; set; }
}