using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Bookshop.Application.Models.Responses;

namespace Unicam.Paradigmi.Bookshop.Web.Factories;

public class BadRequestResultFactory : BadRequestObjectResult
{
    public BadRequestResultFactory(ActionContext context) : base(new BadResponse())
    {
        var retErrors = new List<string>();
        foreach (var key in context.ModelState)
        {
            var errors = key.Value.Errors;
            for (var i = 0; i < errors.Count(); i++)
            {
                retErrors.Add(errors[0].ErrorMessage);
            }
        }

        var response = (BadResponse)Value;
        response.Errors = retErrors;
    }
}