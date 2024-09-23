namespace API.Entities.Orders.Interfaces;

public record OrderState(string State)
{
    public OrderState() : this(String.Empty)
    {
    }
}