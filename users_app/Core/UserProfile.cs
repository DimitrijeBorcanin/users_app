using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using users_app.Application.DTO;
using users_app.Domain;

namespace users_app.Api.Core
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(
                dest => dest.Role,
                map => map.MapFrom(sors => sors.Role.Name));
            CreateMap<UserDto, User>();
        }
    }
}
