using Entities.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto);
        Task<TokenDto> CreateToken(bool populateExpire);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
    }
}
