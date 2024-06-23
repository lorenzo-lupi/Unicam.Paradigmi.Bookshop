using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unicam.Paradigmi.Bookshop.Models.Context;

namespace Unicam.Paradigmi.Bookshop.Models.Extensions;

public static class ServiceExtension
{
    public static void AddMyDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MyDbContext>(options =>
        {
            options.UseMySQL(configuration.GetConnectionString("DefaultConnection"));
        });
    }
}