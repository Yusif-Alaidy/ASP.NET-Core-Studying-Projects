using Auth_tutorial.Entities;
using Auth_tutorial.Models;

namespace Auth_tutorial.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request); 
        Task<TokenResponseDto?> LoginAsync(UserDto request);
        Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request); 
    }
}
