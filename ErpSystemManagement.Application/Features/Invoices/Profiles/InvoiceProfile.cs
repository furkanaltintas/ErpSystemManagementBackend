using AutoMapper;
using ErpSystemManagement.Application.Dtos;
using ErpSystemManagement.Application.Features.Invoices.Commands.CreateInvoice;
using ErpSystemManagement.Application.Features.Invoices.Commands.UpdateInvoice;
using ErpSystemManagement.Domain.Entities;
using ErpSystemManagement.Domain.Enums;

namespace ErpSystemManagement.Application.Features.Invoices.Profiles;

public class InvoiceProfile : Profile
{
    public InvoiceProfile()
    {
        CreateMap<Invoice, InvoiceDetailDto>().ReverseMap();

        CreateMap<CreateInvoiceCommand, Invoice>()
            .ForMember(member => member.InvoiceType, options => options.MapFrom(source => InvoiceEnum.InvoiceTypeName(source.InvoiceType)))
            .ForMember(member => member.Details, options => options.MapFrom(source => source.Details.Select(id => new InvoiceDetail
            {
                ProductId = id.ProductId,
                DepotId = id.DepotId,
                Price = id.Price,
                Quantity = id.Quantity
            }).ToList()));

        CreateMap<UpdateInvoiceCommand, Invoice>()
            .ForMember(member => member.InvoiceType, options => options.MapFrom(source => InvoiceEnum.InvoiceTypeName(source.InvoiceType)))
            .ForMember(member => member.Details, options => options.Ignore())
            .ReverseMap();
    }
}