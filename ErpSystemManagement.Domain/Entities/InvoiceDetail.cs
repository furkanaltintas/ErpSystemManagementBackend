﻿using ErpSystemManagement.Domain.Abstractions;

namespace ErpSystemManagement.Domain.Entities;

public class InvoiceDetail : BaseEntity
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public Guid DepotId { get; set; }

    public decimal Quantity { get; set; }
    public decimal Price { get; set; }

    public Product? Product { get; set; }
    public Depot? Depot { get; set; }
}