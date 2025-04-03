namespace ErpSystemManagement.Application.Dtos;

public record InvoiceDetailDto(
    Guid ProductId,
    Guid DepotId,
    decimal Quantity,
    decimal Price);