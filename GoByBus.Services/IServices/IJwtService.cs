using GoByBus.Core.DTO;
using GoByBus.Core.Models;
using System.Security.Claims;


namespace GoByBus.Services.IServices
{
    public interface IJwtService
    {
        AuthenticationResponse CreateJwtToken(UserDto user);
        ClaimsPrincipal? GetPrincipalFromJwtToken(string? token);
    }
}
