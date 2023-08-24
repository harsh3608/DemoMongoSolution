using GoByBus.API.Helpers;
using GoByBus.Core.DTO;
using GoByBus.Core.Models;
using GoByBus.Services.IServices;
using GoByBus.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoByBus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public UsersController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<ResponseDto<AuthenticationResponse>> RegisterUser(UserAddRequest userAddRequest)
        {
            ResponseDto<AuthenticationResponse> response = new ResponseDto<AuthenticationResponse>();

            //Validation
            if (ModelState.IsValid == false)
            {
                string errorMessage = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                response.StatusCode = 400;
                response.IsSuccess = false;
                response.Response = null;
                response.Message = errorMessage;

                return response;
            }

            userAddRequest.Password = EncryptDecryptHelper.HashData( userAddRequest.Password);

            var addedUser = await _userService.RegisterUser(userAddRequest);

            if(addedUser != null) 
            {
                var authenticationResponse = _jwtService.CreateJwtToken(addedUser);

                response.StatusCode = 200;
                response.IsSuccess = true;
                response.Response = authenticationResponse;
                response.Message = "User registered and logged in successfully";

            }
            else
            {
                response.StatusCode = 500;
                response.IsSuccess = false;
                response.Response = null;
                response.Message = "Server Error Occurred while registering new user.";
            }

            return response;
        }

    }
}
