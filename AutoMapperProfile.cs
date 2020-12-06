using AutoMapper;
using dotnet_user.Dtos.User;
using dotnet_user.Models;

namespace dotnet_user
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();
        }
    }
}