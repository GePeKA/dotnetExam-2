using Main.DataAccess.DatabaseContext;

namespace Main.Infrastructure.UnitOfWork
{
    public class UnitOfWork (AppDbContext dbContext): IUnitOfWork
    {
        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
