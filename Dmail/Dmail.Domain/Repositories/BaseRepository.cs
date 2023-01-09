using Dmail.Data.Entities;
using Dmail.Domain.Enums;

namespace Dmail.Domain.Repositories;

public abstract class BaseRepository
{
    protected readonly DmailDbContext DbContext;

    protected BaseRepository(DmailDbContext dbContext)
    {
        DbContext = dbContext;
    }

    protected Response SaveChanges()
    {
        var hasChanges = DbContext.SaveChanges() > 0;

        return hasChanges ? Response.Success : Response.NoChanges;
    }
}