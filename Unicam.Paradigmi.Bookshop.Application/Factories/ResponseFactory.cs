using Unicam.Paradigmi.Bookshop.Application.Models.Responses;

namespace Unicam.Paradigmi.Bookshop.Application.Factories;

public class ResponseFactory
{
    public static BaseResponse<T> WithSuccess<T>(T result)
    {
        var response = new BaseResponse<T>
        {
            Success = true,
            Result = result
        };
        return response;
    }

    public static BaseResponse<bool> WithError(Exception exception)
    {
        return WithError(exception.Message);
    }

    public static BaseResponse<bool> WithError(string message)
    {
        var response = new BadResponse
        {
            Success = false,
            Errors = new List<string>
            {
                message
            }
        };
        return response;
    }
}