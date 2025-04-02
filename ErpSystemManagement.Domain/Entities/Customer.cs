using ErpSystemManagement.Domain.Abstractions;

namespace ErpSystemManagement.Domain.Entities;

public class Customer : BaseEntity
{
    public Customer()
    {
        Name = string.Empty;
        TaxDepartment = string.Empty;
        TaxNumber = string.Empty;
        City = string.Empty;
        Town = string.Empty;
        FullAddress = string.Empty;
    }

    public Customer(string name, string taxDepartment, string taxNumber, string city, string town, string fullAddress)
    {
        Name = name;
        TaxDepartment = taxDepartment;
        TaxNumber = taxNumber;
        City = city;
        Town = town;
        FullAddress = fullAddress;
    }

    public string Name { get; set; }
    public string TaxDepartment { get; set; }
    public string TaxNumber { get; set; }
    public string City { get; set; }
    public string Town { get; set; }
    public string FullAddress { get; set; }
}
