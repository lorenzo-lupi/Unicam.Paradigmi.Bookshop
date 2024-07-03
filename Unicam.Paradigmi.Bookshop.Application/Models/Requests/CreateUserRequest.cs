using Unicam.Paradigmi.Bookshop.Models.Entities;

namespace Unicam.Paradigmi.Bookshop.Application.Models.Requests;

public class CreateUserRequest
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public User ToEntity()
    {
        var user = new User();
        user.Name = Name;
        user.Surname = Surname;
        user.Email = Email;
        user.Password = Password;
        return user;
    }
}