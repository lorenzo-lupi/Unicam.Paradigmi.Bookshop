using Unicam.Paradigmi.Bookshop.Application.Models.Dtos;
using Unicam.Paradigmi.Bookshop.Models.Entities;

namespace Unicam.Paradigmi.Bookshop.Application.Factories;

public static class BookDtoFactory
{
    public static BookDto FromBook(Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Editor = book.Editor,
            PublicationDate = book.PublicationDate,
            Categories = book.Categories.Select(FromBookCategory).ToList()
        };
            
    }

    private static CategoryDto FromBookCategory(BookCategory bookCategory)
    {
        return new CategoryDto
        {
            Id = bookCategory.CategoryId,
            Name = bookCategory.Category?.Name
        };
    }
}