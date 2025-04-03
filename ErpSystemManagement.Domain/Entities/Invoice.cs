using ErpSystemManagement.Domain.Abstractions;

namespace ErpSystemManagement.Domain.Entities;

public class Invoice : BaseEntity
{
    public Guid CustomerId { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public string InvoiceType { get; set; } = string.Empty;

    public Customer? Customer { get; set; }
    public ICollection<InvoiceDetail>? Details { get; set; }
}
