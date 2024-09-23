namespace API.Entities.Reviews.Interfaces;

public record StarNumber(int Stars)
{
    public StarNumber() : this(0)
    {
    }
}