using App.Application.Services.Authentication;
using App.Contracts.Authentication;
using App.Infrastructure.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace App.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;

        private readonly JwtTokenGenerator _jwtTokenGenerator;


      
        public AuthenticationController(IAuthenticationService authenticationService ,
            JwtTokenGenerator jwtTokenGenerator)
        {
            _authenticationService = authenticationService;
  
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
  
            var authResult = await _authenticationService.RegisterUserAsync(request.Name,request.UserName,request.Email, request.Password);

            return Ok(authResult);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            // Authenticate user (you need to implement this logic, checking if the provided credentials are valid)
            var user = await _authenticationService.AuthenticateUserAsync(request.Email, request.Password);

            if (user == null)
            {
                return Unauthorized(); // Return 401 Unauthorized if authentication fails
            }

            // Generate JWT token
            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Name, user.UserName);

            // Return the token in the response
            return Ok(new { Token = token });
        }
    }
}
