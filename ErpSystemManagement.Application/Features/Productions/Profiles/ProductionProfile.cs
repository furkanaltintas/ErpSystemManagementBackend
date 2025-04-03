using AutoMapper;
using ErpSystemManagement.Application.Features.Productions.Commands.CreateProduction;
using ErpSystemManagement.Domain.Entities;

namespace ErpSystemManagement.Application.Features.Productions.Profiles;

public class ProductionProfile : Profile
{
    public ProductionProfile()
    {
        CreateMap<Production, CreateProductionCommand>().ReverseMap();
    }
}
