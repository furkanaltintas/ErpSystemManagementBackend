using AutoMapper;
using ErpSystemManagement.Application.Features.Depots.Commands.CreateDepot;
using ErpSystemManagement.Application.Features.Depots.Commands.UpdateDepot;
using ErpSystemManagement.Domain.Entities;

namespace ErpSystemManagement.Application.Features.Depots.Profiles;

public class DepotProfile : Profile
{
    public DepotProfile()
    {
        CreateMap<Depot, CreateDepotCommand>().ReverseMap();
        CreateMap<Depot, UpdateDepotCommand>().ReverseMap();
    }
}