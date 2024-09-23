namespace API.Services.Hashing.Interfaces;

public interface IHashingService
{
    Task<string> Handle(string password);
    bool VerifyPassword(string password, string passwordHash);
}