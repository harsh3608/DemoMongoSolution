using Demo.Core.DTO;
using Demo.Core.Models;
using System.Security.Claims;


namespace Demo.Services.IServices
{
    public interface IJwtService
    {
        AuthenticationResponse CreateJwtToken(UserDto user);
        ClaimsPrincipal? GetPrincipalFromJwtToken(string? token);
    }
}
