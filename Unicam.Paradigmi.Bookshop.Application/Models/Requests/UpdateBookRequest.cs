using Unicam.Paradigmi.Bookshop.Application.Models.Dtos;
using Unicam.Paradigmi.Bookshop.Models.Entities;

namespace Unicam.Paradigmi.Bookshop.Application.Models.Requests;

public class UpdateBookRequest
{
    public int Id { get; set; }

    public string? Title { get; set; }
    public string? Author { get; set; }
    public DateTime? PublicationDate { get; set; }
    public string? Editor { get; set; }
    public ICollection<int> CategoryIds { get; set; } = new List<int>();

    public BookDto ToDto()
    {
        var bookDto = new BookDto();
        bookDto.Id = Id;
        bookDto.Title = Title;
        bookDto.Author = Author;
        bookDto.PublicationDate = PublicationDate;
        bookDto.Editor = Editor;
        return bookDto;
    }

    public Book ToEntity()
    {
        var book = new Book();
        book.Id = Id;
        if (Title != null) book.Title = Title;

        if (Author != null) book.Author = Author;

        if (PublicationDate != null) book.PublicationDate = PublicationDate;

        if (Editor != null) book.Editor = Editor;

        return book;
    }
}