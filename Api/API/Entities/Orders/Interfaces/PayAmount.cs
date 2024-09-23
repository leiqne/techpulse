namespace API.Entities.Orders.Interfaces;

public record PayAmount(double Amount)
{
    public PayAmount() : this(0)
    {
    }
}