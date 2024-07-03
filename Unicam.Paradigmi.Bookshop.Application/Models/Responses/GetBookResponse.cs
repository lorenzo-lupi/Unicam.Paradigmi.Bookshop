using Unicam.Paradigmi.Bookshop.Application.Models.Dtos;

namespace Unicam.Paradigmi.Bookshop.Application.Models.Responses;

public class GetBookResponse
{
    public List<BookDto> Books { get; set; } = new();
}