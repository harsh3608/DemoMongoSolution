using AutoMapper;
using Demo.Core.DTO;
using Demo.Core.Entities;
using Demo.Core.Models;
using Demo.Infrastructure.IRepositories;
using Demo.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Services.Services
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
                Id = null,
                PersonName = $"{userRequest.FirstName} {userRequest.LastName}",
                Gender = userRequest.Gender,
                DOB = userRequest.DOB,
                Email = userRequest.Email,
                Phone = userRequest.Phone,
                Password = userRequest.Password,
                CreatedDate = DateTime.Now,
                //UserType = "user",
                UserType = userRequest.UserType,
            };

            var addedUser = await _userRepository.RegisterUser(user);
            UserDto userDto = new UserDto();
            _mapper.Map(addedUser, userDto);
            return userDto;
        }


        public async Task<UserDto> FindUserFromEmail(string mail)
        {
            var user = await _userRepository.FindUserFromEmail(mail);

            if(user == null) { return null; }

            var userDto = new UserDto();
            _mapper.Map(user, userDto);
            return userDto;
        }


    }
}
