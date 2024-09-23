using API.Entities.Users;
using API.Entities.Users.Interfaces;
using API.Repositories.Users.Interfaces;
using API.Services.Auth.Interfaces;
using API.Services.Hashing.Interfaces;
using API.Services.Tokens.Interfaces;

namespace API.Services.Auth;

public class AccountAuthService(IUserRepository userRepository, IHashingService hashingService, ITokenService tokenService) : IAccountAuthService
{
    public async Task<User?> Handle(SignUpResource signUpResource)
    {
        var user = new User(signUpResource);
        user.PHash = await hashingService.Handle(signUpResource.Password);
        await userRepository.Create(user);
        return user;
    }

    public async Task<(User user, string token)> Handle(SignInResource signInResource)
    {
        var user = await userRepository.Search(signInResource.UserName);

        if (user == null || !hashingService.VerifyPassword(signInResource.Password, user.PHash))
        {
            throw new Exception("Invalid username or password");
        }

        var token = tokenService.GenerateToken(user);

        return (user, token);
    }
}