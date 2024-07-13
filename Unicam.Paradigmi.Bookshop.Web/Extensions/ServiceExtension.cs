using System.Text;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Unicam.Paradigmi.Bookshop.Application.Options;
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
        return services.AddEndpointsApiExplorer()
            .AddFluentValidationAutoValidation()
            .AddSwagger()
            .AddJwtAuthentication(configuration)
            .AddOptions(configuration);
    }

    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Paradigmi Progetto Libreria",
                Version = "v1"
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description =
                    "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\""
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
        return services;
    }

    private static IServiceCollection AddJwtAuthentication(this IServiceCollection services,
        IConfiguration configuration)
    {
        var jwtAuthenticationOption = new JwtAuthenticationOption();
        configuration.GetSection("JwtAuthentication")
            .Bind(jwtAuthenticationOption);

        services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var securityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtAuthenticationOption.Key)
                );
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtAuthenticationOption.Issuer,
                    IssuerSigningKey = securityKey,
                    NameClaimType = "user_id"
                };
            });
        return services;
    }

    private static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtAuthenticationOption>(
            configuration.GetSection("JwtAuthentication"));
        return services;
    }
}