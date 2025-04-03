using ErpSystemManagement.Domain.Abstractions;

namespace ErpSystemManagement.Domain.Entities;

public class StockMovement : BaseEntity
{
    public Guid ProductId { get; set; }
    public Guid DepotId { get; set; }
    public Guid? InvoiceId { get; set; }
    public Guid? ProductionId { get; set; }
    public decimal NumberOfEntries { get; set; }
    public decimal NumberOfOutpus { get; set; }
    public decimal Price { get; set; }

    public Product? Product { get; set; }
    public Invoice? Invoice { get; set; }
    public Production? Production { get; set; }
}
