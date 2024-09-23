namespace API.Entities.Providers.Interfaces;

public record ProviderAddress(string Address)
{
    public ProviderAddress() : this(String.Empty)
    {
    }
}