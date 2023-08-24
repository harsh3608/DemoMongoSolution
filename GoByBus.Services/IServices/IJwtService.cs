using GoByBus.Core.Entities;
using GoByBus.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GoByBus.Services.IServices
{
    public interface IJwtService
    {
        AuthenticationResponse CreateJwtToken(UserEntity user);
        ClaimsPrincipal? GetPrincipalFromJwtToken(string? token);
    }
}
