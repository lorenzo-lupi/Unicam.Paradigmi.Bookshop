using Unicam.Paradigmi.Bookshop.Application.Abstractions.Services;
using Unicam.Paradigmi.Bookshop.Application.CustomExceptions;
using Unicam.Paradigmi.Bookshop.Models.Entities;
using Unicam.Paradigmi.Bookshop.Models.Repositories;

namespace Unicam.Paradigmi.Bookshop.Application.Services;

public class UserService : IUserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        if ( await UserEmailExistsInDatabase(user.Email) )
        {
            throw new UserAlreadyExistsInDatabase(user.Email);
        }

        _userRepository.Add(user);
        await _userRepository.SaveAsync();
        return user;
    }

    private async Task<bool> UserEmailExistsInDatabase(string email)
    {
        return await _userRepository.GetUserByEmailAsync(email) != null;
    }
}