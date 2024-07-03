using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unicam.Paradigmi.Bookshop.Application.Abstractions.Services;
using Unicam.Paradigmi.Bookshop.Application.Services;
using Unicam.Paradigmi.Bookshop.Application.Validators;

namespace Unicam.Paradigmi.Bookshop.Application.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IBookService, BookService>();
        AddValidationServices(services);
        return services;
    }

    private static void AddValidationServices(IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        //TODO
        /*services.AddValidatorsFromAssembly(
            AppDomain.CurrentD omain.GetAssemblies().SingleOrDefault(assembly =>
                assembly.GetName().Name == "Unicam.Paradigmi.Application" ));
    */
        services.AddValidatorsFromAssemblyContaining<CreateUserRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateCategoryRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<RemoveCategoryRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateBookRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<GetBookRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<DeleteBookRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateBookRequestValidator>();
    }
}