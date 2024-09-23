using API.Entities.Providers;

namespace API.Repositories.Providers.Interfaces;

public interface IProviderRepository
{
    Task Create(Provider providers);
    Task<Provider?> SearchById(int id);
}