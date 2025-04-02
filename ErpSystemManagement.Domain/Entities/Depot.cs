using ErpSystemManagement.Domain.Abstractions;

namespace ErpSystemManagement.Domain.Entities;

public class Depot : BaseEntity
{
    public Depot()
    {
        Name = string.Empty;
        City = string.Empty;
        Town = string.Empty;
        FullAddress = string.Empty;
    }

    public Depot(string name, string city, string town, string fullAddress)
    {
        Name = name;
        City = city;
        Town = town;
        FullAddress = fullAddress;
    }

    public string Name { get; set; }
    public string City { get; set; }
    public string Town { get; set; }
    public string FullAddress { get; set; }
}