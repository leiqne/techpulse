namespace API.Entities.Products.Interfaces;

public record ProductName(string Name)
{
    public ProductName() : this(String.Empty)
    {
    }
}