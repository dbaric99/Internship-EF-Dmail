using Dmail.Domain.Repositories;

namespace Dmail.Domain.Factories;

public class RepositoryFactory
{
    public static TRepository Create<TRepository>()
        where TRepository : BaseRepository
    {
        var dbContext = DbContextFactory.GetDmailDbContext();
        return (Activator.CreateInstance(typeof(TRepository), dbContext) as TRepository)!;
    }
}