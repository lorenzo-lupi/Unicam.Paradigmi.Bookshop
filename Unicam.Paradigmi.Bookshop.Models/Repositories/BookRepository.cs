using Microsoft.EntityFrameworkCore;
using Unicam.Paradigmi.Bookshop.Models.Context;
using Unicam.Paradigmi.Bookshop.Models.Entities;

namespace Unicam.Paradigmi.Bookshop.Models.Repositories;

public class BookRepository : GenericRepository<Book>
{
    public BookRepository(MyDbContext context) : base(context)
    {
        
    }

    public async Task<List<Book>> GetBooksAsync(int page, int pageSize, 
        string? bookName, DateTime? publicationTime, string? author)
    {
        var query = Context.Books.AsQueryable();
        
        query = FilterByTitle(query, bookName);
        query = FilterByPublicationTime(query, publicationTime);
        query = FilterByAuthor(query, author);
        
        return await query.OrderBy(q => q.Title)
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    
    private static IQueryable<Book> FilterByTitle(IQueryable<Book> query, string? bookName)
    {
        return string.IsNullOrWhiteSpace(bookName) ? query : query.Where(b => b.Title.Contains(bookName));
    }
    
    private static IQueryable<Book> FilterByPublicationTime(IQueryable<Book> query, DateTime? publicationTime)
    {
        return !publicationTime.HasValue ? query : query.Where(b => b.PublicationDate == publicationTime);
    }
    
    private static IQueryable<Book> FilterByAuthor(IQueryable<Book> query, string? author)
    {
        return string.IsNullOrWhiteSpace(author) ? query : query.Where(b => b.Author.Contains(author));
    }
}