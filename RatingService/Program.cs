using RatingService.Configurations;
using RatingService.Data.Repositories;
using RatingService.ServicesExtensions.JwtAuthentication;
using RatingService.ServicesExtensions.MassTransit;
using RatingService.ServicesExtensions.Mediator;
using RatingService.ServicesExtensions.Mongo;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.AddCustomMediator();
builder.Services.AddMasstransitRabbitMq(
    builder.Configuration.GetSection("RabbitMqConfig").Get<RabbitMqConfig>()!
);
builder.Services.AddMongoDb(
    builder.Configuration.GetSection("MongoDbConfig").Get<MongoDbConfig>()!
);
builder.Services.AddTransient<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
