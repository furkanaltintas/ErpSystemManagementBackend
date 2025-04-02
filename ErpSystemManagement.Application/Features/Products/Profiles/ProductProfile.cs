using AutoMapper;
using ErpSystemManagement.Application.Dtos;
using ErpSystemManagement.Application.Features.Products.Commands.CreateProduct;
using ErpSystemManagement.Application.Features.Products.Commands.UpdateProduct;
using ErpSystemManagement.Domain.Entities;

namespace ErpSystemManagement.Application.Features.Products.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, CreateProductCommand>()
            .ReverseMap();


        CreateMap<Product, UpdateProductCommand>()
            .ReverseMap();

        CreateMap<Product, ProductDto>().ReverseMap();
    }
}