using AutoMapper;
using ErpSystemManagement.Application.Dtos;
using ErpSystemManagement.Application.Features.RecipeDetails.Commands.CreateRecipeDetail;
using ErpSystemManagement.Application.Features.RecipeDetails.Commands.UpdateRecipeDetail;
using ErpSystemManagement.Domain.Entities;

namespace ErpSystemManagement.Application.Features.RecipeDetails.Profiles;

public class RecipeDetailProfile : Profile
{
    public RecipeDetailProfile()
    {
        CreateMap<RecipeDetail, RecipeDetailDto>().ReverseMap();
        CreateMap<RecipeDetail, CreateRecipeDetailCommand>().ReverseMap();
        CreateMap<RecipeDetail, UpdateRecipeDetailCommand>().ReverseMap();
    }
}