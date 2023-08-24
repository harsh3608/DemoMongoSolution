using AutoMapper;
using GoByBus.Core.DTO;
using GoByBus.Core.Entities;
using GoByBus.Core.Models;
using GoByBus.Infrastructure.IRepositories;
using GoByBus.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoByBus.Services.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> RegisterUser(UserAddRequest userRequest)
        {
            UserEntity user = new UserEntity()
            {
                Id = userRequest.Id,
                PersonName = $"{userRequest.FirstName} {userRequest.LastName}",
                Gender = userRequest.Gender,
                DOB = userRequest.DOB,
                Email = userRequest.Email,
                Phone = userRequest.Phone,
                Password = userRequest.Password,
                CreatedDate = DateTime.Now,
                UserType = userRequest.UserType,
            };

            var addedUser = await _userRepository.RegisterUser(user);
            UserDto userDto = new UserDto();
            _mapper.Map(addedUser, userDto);
            return userDto;
        }
    }
}
