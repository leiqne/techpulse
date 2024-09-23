using API.Entities.Users;

namespace API.Services.Tokens.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}