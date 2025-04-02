using AutoMapper;
using ErpSystemManagement.Application.Features.Customers.Commands.CreateCustomer;
using ErpSystemManagement.Application.Features.Customers.Commands.UpdateCustomer;
using ErpSystemManagement.Domain.Entities;

namespace ErpSystemManagement.Application.Features.Customers.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
        CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
    }
}