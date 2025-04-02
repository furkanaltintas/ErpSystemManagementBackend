namespace ErpSystemManagement.Application.Dtos;

public record OrderDetailDto(
     Guid ProductId,
     decimal Quantity,
     decimal Price);