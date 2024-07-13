using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Bookshop.Application.Models.Responses;

namespace Unicam.Paradigmi.Bookshop.Web.Factories;

public class BadRequestResultFactory : BadRequestObjectResult
{
    public BadRequestResultFactory(ActionContext context) : base(new BadResponse())
    {
        var retErrors = new List<string>();

        foreach (var key in context.ModelState) retErrors.AddRange(key.Value.Errors.Select(e => e.ErrorMessage));

        var response = (BadResponse)Value!;
        response.Errors = retErrors;
    }
}