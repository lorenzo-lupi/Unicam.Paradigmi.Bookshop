namespace Unicam.Paradigmi.Bookshop.Application.Models.Dtos;

public class BookDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public DateTime? PublicationDate { get; set; }
    public string? Editor { get; set; }
    public ICollection<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
}