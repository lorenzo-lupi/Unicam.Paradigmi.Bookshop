using Unicam.Paradigmi.Bookshop.Models.Entities;

namespace Unicam.Paradigmi.Bookshop.Application.Models.Requests;

public class RemoveCategoryRequest
{
    public int Id { get; set; }

    public Category ToEntity()
    {
        var category = new Category();
        category.Id = Id;
        return category;
    }
}