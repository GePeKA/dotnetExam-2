using Main.DataAccess.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Main.API.ServicesExtensions.Migrations;

public static class WebApplicationExtensions
{
    public async static Task MigrateIfNeededAsync(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        await Task.Delay(2000);

        var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
        if ((await dbContext!.Database.GetPendingMigrationsAsync()).Any())
        {
            await dbContext.Database.MigrateAsync();
        }
    }
}
