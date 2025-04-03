using ErpSystemManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErpSystemManagement.Persistence.Configurations;

class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        
    }
}

class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
{
    public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
    {
        
    }
}
