namespace API.Entities.Providers.Interfaces;

public record ProviderName(string Name)
{
    public ProviderName() : this(String.Empty)
    {
    }
}