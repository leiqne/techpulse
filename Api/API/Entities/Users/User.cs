using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;
using API.Entities.Orders;
using API.Entities.Reviews;
using API.Entities.Users.Interfaces;

namespace API.Entities.Users;

public class User
{
    public User()
    {
        Name = new UserName();
        Email = new EmailAddress();
        Number = new PhoneNumber();
    }

    public User(SignUpResource signUpResource)
    {
        Name = new UserName(signUpResource.UserName);
        Email = new EmailAddress(signUpResource.EmailAddress);
        Number = new PhoneNumber(signUpResource.PhoneNumber);
    }

    public int Id { get; }
    public UserName Name { get; set; }
    public EmailAddress Email { get; set; }
    public PhoneNumber Number { get; set; }
    [JsonIgnore] public string PHash { get; set; }

    public ICollection<Review> Reviews { get; }
    public ICollection<Order> Orders { get; }
}