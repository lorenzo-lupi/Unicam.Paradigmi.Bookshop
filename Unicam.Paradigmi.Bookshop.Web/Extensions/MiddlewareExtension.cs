using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Unicam.Paradigmi.Bookshop.Application.Factories;

namespace Unicam.Paradigmi.Bookshop.Web.Extensions;

public static class MiddlewareExtension
{
    public static WebApplication UseWebApiMiddlewares(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.SetUpExceptionHandler()
            .UseHttpsRedirection()
            .UseAuthentication()
            .UseAuthorization();
        app.MapControllers();
        return app;
    }

    /*
        creation of an alternative pipeline to use
       to handle exceptions abookDto.Categories = book.Categories.Select()nd to provide a standard response
       for errors
    */
    private static WebApplication SetUpExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    var res = ResponseFactory.WithError(contextFeature.Error);
                    await context.Response.WriteAsJsonAsync(res);
                }
            });
        });
        return app;
    }
}