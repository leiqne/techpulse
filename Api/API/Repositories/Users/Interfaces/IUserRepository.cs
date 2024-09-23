using API.Entities.Users;

namespace API.Repositories.Users.Interfaces;

public interface IUserRepository
{
    Task Create(User user);
    Task<User?> Search(string name);
    Task<User?> SearchById(int id);
}