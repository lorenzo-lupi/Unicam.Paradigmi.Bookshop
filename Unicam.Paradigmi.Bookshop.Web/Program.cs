using Unicam.Paradigmi.Bookshop.Application.Extensions;
using Unicam.Paradigmi.Bookshop.Models.Extensions;
using Unicam.Paradigmi.Bookshop.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddModelServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddWebServices(builder.Configuration);

var app = builder.Build();

app.UseWebApiMiddlewares();

app.Run();