using Unicam.Paradigmi.Bookshop.Models.Entities;

namespace Unicam.Paradigmi.Bookshop.Application.Models.Requests;

public class CreateBookRequest
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public DateTime? PublicationDate { get; set; }
    public string? Editor { get; set; }
    public ICollection<int> CategoryIds { get; set; } = new List<int>();

    public virtual Book ToEntity()
    {
        var book = new Book();
        book.Title = Title;
        book.Author = Author;
        book.PublicationDate = PublicationDate;
        book.Editor = Editor;
        return book;
    }
}