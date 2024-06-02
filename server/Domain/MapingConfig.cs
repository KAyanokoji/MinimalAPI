using AutoMapper;
using server.Domain.DTOs;
using server.Domain.Models;

namespace server.Domain
{
    public class MapingConfig:Profile
    {
        public MapingConfig()
        {
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }

    }
}

