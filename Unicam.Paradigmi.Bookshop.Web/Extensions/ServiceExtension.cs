using Unicam.Paradigmi.Bookshop.Web.Factories;

namespace Unicam.Paradigmi.Bookshop.Web.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers()
            .ConfigureApiBehaviorOptions(opt =>
            {
                opt.InvalidModelStateResponseFactory = context => new BadRequestResultFactory(context);
            });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}