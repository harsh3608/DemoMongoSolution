using AutoMapper;
using Demo.Core.DTO;
using Demo.Core.Entities;
using System;

namespace Demo.API.MappingProfile
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
        }
    }
}
