using System.Text.Json.Serialization;

namespace Unicam.Paradigmi.Bookshop.Application.Models.Dtos;

public class CategoryDto
{
    public int Id { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
}