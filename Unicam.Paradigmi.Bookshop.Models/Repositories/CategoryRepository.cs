using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Bookshop.Models.Context;
using Unicam.Paradigmi.Bookshop.Models.Entities;

namespace Unicam.Paradigmi.Bookshop.Models.Repositories;

public class CategoryRepository : GenericRepository<Category>
{
    public CategoryRepository(MyDbContext context) : base(context)
    {
    }
    
    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await Context.Categories.FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<Category?> GetCategoryByNameAsync(string name)
    {
        return await Context.Categories.FirstOrDefaultAsync(c => c.Name.Equals(name));
    }
}