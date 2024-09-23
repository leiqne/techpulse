using API.Configuration;
using API.Entities.Users;
using API.Repositories.Users.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Users;

public class UserRepository : IUserRepository
{
    protected readonly AppDbContext Context;

    public UserRepository(AppDbContext context)
    {
        Context = context;
    }

    public async Task Create(User user)
    {
        await Context.Set<User>().AddAsync(user);
        await Context.SaveChangesAsync();
    }

    public async Task<User?> Search(string name)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.Name.Name.Equals(name));
    }

    public async Task<User?> SearchById(int id)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.Id.Equals(id));
    }
}