using API.Entities.Providers;
using API.Entities.Providers.Interfaces;

namespace API.Services.Providers.Interfaces;

public interface IProviderService
{
    Task<Provider?> Handle(ProviderResource providerResource);
}