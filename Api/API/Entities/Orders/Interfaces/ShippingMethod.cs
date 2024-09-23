namespace API.Entities.Orders.Interfaces;

public record ShippingMethod(string Shipping)
{
    public ShippingMethod() : this(String.Empty)
    {
    }
}