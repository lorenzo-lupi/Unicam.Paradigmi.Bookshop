namespace Unicam.Paradigmi.Bookshop.Application.Models.Requests;

public class GetBookRequest
{
    // int page, int pageSize, 
    // string? bookName, DateTime? publicationTime, string? author

    public int Page { get; set; }
    public int PageSize { get; set; }
    public string? BookName { get; set; }
    public DateTime? PublicationDate { get; set; }
    public string? Author { get; set; }
}