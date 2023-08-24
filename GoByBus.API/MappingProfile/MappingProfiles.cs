using AutoMapper;
using GoByBus.Core.DTO;
using GoByBus.Core.Entities;
using System;

namespace GoByBus.API.MappingProfile
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
        }
    }
}
