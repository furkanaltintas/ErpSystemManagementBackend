namespace ErpSystemManagement.Application.Dtos;

public record RequirementProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Quantity { get; set; }

    public RequirementProductDto()
    {
        Name = string.Empty;
    }

    public RequirementProductDto(Guid id, string name, decimal quantity)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
    }
}

