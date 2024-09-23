using API.Entities.Products;
using API.Entities.Providers.Interfaces;

namespace API.Entities.Providers;

public class Provider
{
    public Provider()
    {
        Name = new ProviderName();
        Address = new ProviderAddress();
        Link = new ProviderLink();
    }

    public Provider(ProviderResource providerResource)
    {
        Name = new ProviderName(providerResource.Name);
        Address = new ProviderAddress(providerResource.Address);
        Link = new ProviderLink(providerResource.Link);
    }

    public int Id { get; }
    public ProviderName Name { get; set; }
    public ProviderAddress Address { get; set; }
    public ProviderLink Link { get; set; }
    public ICollection<Product> Products { get; }
}