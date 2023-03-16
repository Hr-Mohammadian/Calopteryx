using System.Reflection;
using Calopteryx.Bootstrapper.Configurations;
using Microsoft.AspNetCore.Builder;
using Calopteryx.BuildingBlocks.Infrastructures;
using Calopteryx.Modules.Catalog.Api;
using Calopteryx.Modules.Identity.Api;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication
    .CreateBuilder(args);
builder.Host.AddConfigurations();
builder.Host.UseSerilog((_, config) =>
{
    config.WriteTo.Console()
        .ReadFrom.Configuration(builder.Configuration);
});
builder.Services.AddInfrustructure(builder.Configuration);
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddIdentityModule(builder.Configuration);
builder.Services.AddCatalogModule();
builder.Services.AddSharedFramework(builder.Configuration);

var assembly = Assembly.GetExecutingAssembly();
builder.Services
    .AddValidatorsFromAssembly(assembly)
    .AddMediatR(assembly);

var app = builder.Build();
app.UseSharedFramework(builder.Configuration);
app.UseIdentityModule(app.Services.CreateScope().ServiceProvider);
app.UseCatalogModule();
app.MapEndpoints();

app.Run();