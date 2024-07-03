using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Bookshop.Models.Context;
using Unicam.Paradigmi.Bookshop.Models.Entities;

namespace Unicam.Paradigmi.Bookshop.Models.Repositories;

public class CategoryRepository : GenericRepository<Category>
{
    /*
     * <summary>
     *
     * </summary>
     */
    public CategoryRepository(MyDbContext context) : base(context)
    {
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await Context.Categories.FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<bool> CategoryExists(string name)
    {
        return await Context.Categories.AnyAsync(c => c.Name.Equals(name));
    }

    public async Task<List<Category>> GetCategoriesInCollectionAsync(ICollection<int> categoryIds)
    {
        return await Context.Categories.Where(c => categoryIds.Contains(c.Id)).ToListAsync();
    }

    public async Task<int> GetNumberOfExistingCategoriesInCollectionAsync(ICollection<int> categoryIds)
    {
        return await Context.Categories.CountAsync(c => categoryIds.Contains(c.Id));
    }
}