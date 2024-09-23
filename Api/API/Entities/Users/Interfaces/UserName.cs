namespace API.Entities.Users.Interfaces;

public record UserName(string Name)
{
    public UserName() : this(string.Empty)
    {
    }
}