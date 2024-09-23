using API.Entities.Providers;
using API.Entities.Providers.Interfaces;
using API.Repositories.Providers.Interfaces;
using API.Services.Providers.Interfaces;

namespace API.Services.Providers;

public class ProviderService(IProviderRepository providerRepository) : IProviderService
{
    public async Task<Provider?> Handle(ProviderResource providerResource)
    {
        var provider = new Provider(providerResource);
        await providerRepository.Create(provider);
        return provider;
    }
}