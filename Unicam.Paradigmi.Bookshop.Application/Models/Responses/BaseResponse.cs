using System.Text.Json.Serialization;

namespace Unicam.Paradigmi.Bookshop.Application.Models.Responses;

public class BaseResponse<T>
{
    public bool Success { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? Errors { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public T? Result { get; set; }
}