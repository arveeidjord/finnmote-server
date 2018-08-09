using AutoMapper;
using FinnMote.Api.Dto;
using FinnMote.Api.Models;

namespace FinnMote.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}