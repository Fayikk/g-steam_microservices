using AutoMapper;
using Contracts;
using GameService.DTOs;
using GameService.DTOs.ForCategory;
using GameService.Entities;

namespace GameService.RequestHelpers;


public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category,CreateCategoryDTO>().ReverseMap();
        CreateMap<CreateGameDTO,Game>().ReverseMap();
        CreateMap<CreateGameDTO,AddGame>();
        CreateMap<Game,AddGame>();
    }
}