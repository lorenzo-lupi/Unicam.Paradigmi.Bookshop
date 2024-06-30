using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Bookshop.Models.Context;
using Unicam.Paradigmi.Bookshop.Models.Entities;

namespace Unicam.Paradigmi.Bookshop.Models.Repositories;

public class UserRepository : GenericRepository<User>
{
    public UserRepository(MyDbContext context) : base(context)
    {
    }
    
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await Context.Users
            .FirstOrDefaultAsync(q => q.Email.Equals(email));
    }
    
}