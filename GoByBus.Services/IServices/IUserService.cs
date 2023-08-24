using GoByBus.Core.DTO;
using GoByBus.Core.Entities;
using GoByBus.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoByBus.Services.IServices
{
    public interface IUserService
    {
        Task<UserDto> RegisterUser(UserAddRequest userRequest);

        Task<UserDto> FindUserFromEmail(string mail);
    }
}
