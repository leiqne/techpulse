namespace API.Entities.Reviews.Interfaces;

public record ReviewContent(string Content)
{
    public ReviewContent() : this(String.Empty)
    {
    }
}