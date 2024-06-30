using Unicam.Paradigmi.Bookshop.Models.Entities;

namespace Unicam.Paradigmi.Bookshop.Application.Abstractions.Services;

public interface ICategoryService
{
    public Task<Category> CreateCategoryAsync(Category category);
    public Task<bool> RemoveCategoryAsync(int categoryId);
}