using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unicam.Paradigmi.Bookshop.Models.Context;
using Unicam.Paradigmi.Bookshop.Models.Repositories;

namespace Unicam.Paradigmi.Bookshop.Models.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMyDbContext(configuration)
            .AddRepositories();
        return services;
    }

    private static IServiceCollection AddMyDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MyDbContext>(options =>
        {
            options.UseMySQL(configuration.GetConnectionString("MyDbContext"));
        });
        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<BookRepository>();
        services.AddScoped<UserRepository>();
        services.AddScoped<CategoryRepository>();
    }
}