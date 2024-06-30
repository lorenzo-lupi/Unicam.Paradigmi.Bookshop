using Unicam.Paradigmi.Bookshop.Models.Entities;

namespace Unicam.Paradigmi.Bookshop.Application.Models.Dtos;

public class UserDto
{
    public UserDto()
    {
        
    }
    public UserDto(User user)
    {
        Id = user.Id;
        Name = user.Name;
        Surname = user.Surname;
        Email = user.Email;
        Password = user.Password;
    }
    
    public int Id { get; set;}
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}