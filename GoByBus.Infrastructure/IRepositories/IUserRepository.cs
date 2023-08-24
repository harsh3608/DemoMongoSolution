﻿using GoByBus.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoByBus.Infrastructure.IRepositories
{
    public interface IUserRepository
    {
        Task<UserEntity> RegisterUser(UserEntity user);

        Task<UserEntity> FindUserFromEmail(string mail);

        
    }
}
