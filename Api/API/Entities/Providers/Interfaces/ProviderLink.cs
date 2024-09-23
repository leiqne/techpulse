namespace API.Entities.Providers.Interfaces;

public record ProviderLink(string Link)
{
    public ProviderLink() : this(String.Empty)
    {
    }
}