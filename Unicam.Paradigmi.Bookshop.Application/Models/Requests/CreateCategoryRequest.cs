using Unicam.Paradigmi.Bookshop.Application.Models.Dtos;
using Unicam.Paradigmi.Bookshop.Models.Entities;

namespace Unicam.Paradigmi.Bookshop.Application.Models.Requests;

public class CreateCategoryRequest
{
    public string Name { get; set; } = string.Empty;

    public Category ToEntity()
    {
        var category = new Category();
        category.Name = Name;
        return category;
    }
}