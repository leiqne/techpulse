using API.Configuration;
using API.Entities.Providers;
using API.Repositories.Providers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Providers;

public class ProviderRepository : IProviderRepository
{
    protected readonly AppDbContext Context;

    public ProviderRepository(AppDbContext context)
    {
        Context = context;
    }

    public async Task Create(Provider provider)
    {
        await Context.Set<Provider>().AddAsync(provider);
        await Context.SaveChangesAsync();
    }

    public async Task<Provider?> SearchById(int id)
    {
        return await Context.Set<Provider>().FirstOrDefaultAsync(provider => provider.Id.Equals(id));
    }
}