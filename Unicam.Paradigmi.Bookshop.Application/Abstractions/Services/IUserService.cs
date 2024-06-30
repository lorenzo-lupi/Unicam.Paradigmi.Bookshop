using Unicam.Paradigmi.Bookshop.Models.Entities;

namespace Unicam.Paradigmi.Bookshop.Application.Abstractions.Services;

public interface IUserService
{
    public Task<User> CreateUserAsync(User user);
}