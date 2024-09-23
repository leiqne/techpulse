namespace API.Entities.Users.Interfaces;

public record PhoneNumber(string Number)
{
    public PhoneNumber() : this(String.Empty)
    {
    }
}