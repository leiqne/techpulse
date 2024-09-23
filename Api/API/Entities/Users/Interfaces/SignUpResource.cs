namespace API.Entities.Users.Interfaces;

public record SignUpResource(string UserName, string EmailAddress, string PhoneNumber, string Password);