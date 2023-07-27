using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(RegisterRequest request);
        Task<AuthenticateResponse> AuthenticateUserAsync(LoginRequest request);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
