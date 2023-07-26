using App.Application.Common.Interfaces.Authentication;
using App.Application.Common.Interfaces.Presistence;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public AuthenticationResult Register(string name, string userName, string email, string password)
        {
            // if user Exists
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("user already Exists");
            }
            // create nre user
            var user = new User { Name = name, UserName = userName, Email = email, Password = password };

            _userRepository.Add(user);

            // Create JWT
            var token = _jwtTokenGenerator.GenerateToken(user.Id, name, userName);

            return new AuthenticationResult(user.Id, name, userName, email, token);
        }

        public AuthenticationResult Login( string email, string password)
        {
            // if user Exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("user with this mail doesn't exist ");
            }
            // Validate Password is correct 
            if (user.Password != password)
            {
                throw new Exception("user with this mail doesn't exist ");
            }
            // Create JWT
            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Name, user.UserName);

            return new AuthenticationResult(user.Id, user.Name, user.UserName ,email , token);
        }
    }
}
