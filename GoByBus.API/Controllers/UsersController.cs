using Demo.API.Helpers;
using Demo.Core.DTO;
using Demo.Core.Models;
using Demo.Services.IServices;
using Demo.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
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

            var existingUser = await _userService.FindUserFromEmail(userAddRequest.Email);

            if(existingUser == null)
            {
                var addedUser = await _userService.RegisterUser(userAddRequest);

                if (addedUser != null)
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
            }
            else
            {
                response.StatusCode = 409;
                response.IsSuccess = false;
                response.Response = null;
                response.Message = $"An user already exists with '{userAddRequest.Email}' mail address.";
            }

            return response;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ResponseDto<AuthenticationResponse>> LoginUser(UserLogin loginRequest)
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

            var user = await _userService.FindUserFromEmail(loginRequest.Email);

            if (user != null)
            {
                bool isVerified = EncryptDecryptHelper.VerifyHash(loginRequest.Password, user.Password);
                
                if(isVerified) 
                {
                    var authenticationResponse = _jwtService.CreateJwtToken(user);

                    response.StatusCode = 200;
                    response.IsSuccess = true;
                    response.Response = authenticationResponse;
                    response.Message = "User logged in successfully";
                }
                else
                {
                    response.StatusCode = 401;
                    response.IsSuccess = false;
                    response.Response = null;
                    response.Message = "Wrong credentials entered !";
                }
            }
            else
            {
                response.StatusCode = 404;
                response.IsSuccess = false;
                response.Response = null;
                response.Message = "user Not Found !";
            }


            return response;
        }

    }
}
