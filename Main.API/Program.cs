using Main.API.ServicesExtensions.DataAccess;
using Main.API.ServicesExtensions.Infrastructure;
using Main.API.ServicesExtensions.JwtAuth;
using Main.API.ServicesExtensions.Mediator;
using Main.API.ServicesExtensions.Migrations;
using Main.DataAccess.DatabaseContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddDataAccessLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);

builder.Services.AddCustomMediator();

var app = builder.Build();

await app.MigrateIfNeededAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
