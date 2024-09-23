namespace API.Entities.Users.Interfaces;

public record EmailAddress(string Email)
{
    public EmailAddress() : this(String.Empty)
    {
    }
}