using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Bookshop.Models.Context;
using Unicam.Paradigmi.Bookshop.Models.Entities;

namespace Unicam.Paradigmi.Bookshop.Models.Repositories;

public class UserRepository : GenericRepository<User>
{
    public UserRepository(MyDbContext context) : base(context)
    {
    }

    public async Task<bool> EmailExistsInDatabaseAsync(string email)
    {
        return await Context.Users.AnyAsync(q => q.Email.Equals(email));
    }

    public async Task<User?> GetUserFromEmailAndPassword(string email, string password)
    {
        return await Context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Password.Equals(password));
    }
}