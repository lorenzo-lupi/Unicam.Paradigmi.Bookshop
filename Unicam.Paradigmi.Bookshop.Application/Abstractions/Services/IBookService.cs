using Unicam.Paradigmi.Bookshop.Application.Models.Dtos;
using Unicam.Paradigmi.Bookshop.Models.Entities;

namespace Unicam.Paradigmi.Bookshop.Application.Abstractions.Services;

public interface IBookService
{
    public Task<Book> CreateBookAsync(Book book, ICollection<int> categoryIds);

    public Task<Book> UpdateBookAsync(BookDto bookDto, ICollection<int> categoryIds);

    public Task<bool> DeleteBookAsync(int bookId);

    public Task<List<Book>> GetBookAsync(int page, int pageSize,
        string? bookName, DateTime? publicationTime, string? author);
}