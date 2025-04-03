using ErpSystemManagement.Domain.Abstractions;

namespace ErpSystemManagement.Domain.Entities
{
    public class Production : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid DepotId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Product? Product { get; set; }
        public Depot? Depot { get; set; }
    }
}
