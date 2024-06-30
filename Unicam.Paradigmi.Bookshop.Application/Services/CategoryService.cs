using Unicam.Paradigmi.Bookshop.Application.Abstractions.Services;
using Unicam.Paradigmi.Bookshop.Application.CustomExceptions;
using Unicam.Paradigmi.Bookshop.Models.Entities;
using Unicam.Paradigmi.Bookshop.Models.Repositories;

namespace Unicam.Paradigmi.Bookshop.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly CategoryRepository _categoryRepository;

    public CategoryService(CategoryRepository categoryRepository)
    {
        this._categoryRepository = categoryRepository;
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        if (await CategoryIsInDatabaseAsync(category.Name))
        {
            throw new CategoryAlreadyExistsInDatabase(category.Name);
        }

        _categoryRepository.Add(category);
        await _categoryRepository.SaveAsync();
        return category;
    }

    public async Task<bool> RemoveCategoryAsync(int categoryId)
    {
        var category = GetCategoryByIdAsync(categoryId);
        if (category.Result == null)
        {
            throw new CategoryNotInDatabase($"{categoryId}");
        }

        _categoryRepository.Remove(category.Result);
        await _categoryRepository.SaveAsync();
        return true;
    }

    private async Task<bool> CategoryIsInDatabaseAsync(string name)
    {
        return await _categoryRepository.GetCategoryByNameAsync(name) != null;
    }
    
    private async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await _categoryRepository.GetCategoryByIdAsync(id);
    }
}