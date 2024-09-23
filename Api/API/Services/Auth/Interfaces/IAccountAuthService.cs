using API.Entities.Users;
using API.Entities.Users.Interfaces;

namespace API.Services.Auth.Interfaces;

public interface IAccountAuthService
{
    Task<User?> Handle(SignUpResource signUpResource);
    Task<(User user, string token)> Handle(SignInResource signInResource);
}