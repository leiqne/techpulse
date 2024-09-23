using API.Services.Hashing.Interfaces;
using BCryptNet = BCrypt.Net.BCrypt;

namespace API.Services.Hashing;

public class HashingService : IHashingService
{
    public async Task<string> Handle(string password)
    {
        return BCryptNet.HashPassword(password);
    }
    
    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCryptNet.Verify(password, passwordHash);
    }
}