using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Dmail.Domain.Enums;

namespace Dmail.Domain.Repositories;

public class SpamAccountRepository : BaseRepository
{
    public SpamAccountRepository(DmailDbContext dbContext) : base(dbContext)
    {
        
    }

    public Response Add(SpamAccount newSpamAccount)
    {
        DbContext.SpamAccounts.Add(newSpamAccount);
        return SaveChanges();
    }

    public Response Delete(int idToDelete)
    {
        var spamAccountToDelete = DbContext.SpamAccounts.Find(idToDelete);
        if (spamAccountToDelete is null) return Response.NotFound;

        DbContext.SpamAccounts.Remove(spamAccountToDelete);
        
        return SaveChanges();
    }
}