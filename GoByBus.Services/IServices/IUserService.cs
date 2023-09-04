using Demo.Core.DTO;
using Demo.Core.Entities;
using Demo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Services.IServices
{
    public interface IUserService
    {
        Task<UserDto> RegisterUser(UserAddRequest userRequest);

        Task<UserDto> FindUserFromEmail(string mail);
    }
}
