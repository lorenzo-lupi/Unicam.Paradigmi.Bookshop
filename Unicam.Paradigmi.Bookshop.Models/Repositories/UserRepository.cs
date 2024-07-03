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
}