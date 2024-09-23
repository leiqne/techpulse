namespace API.Entities.Orders.Interfaces;

public record OrderDate(DateTime Date)
{
    public OrderDate() : this(new DateTime(0, 0, 0))
    {
    }
}