using Dmail.Data.Entities;
using Dmail.Data.Entities.Models;
using Dmail.Domain.Enums;

namespace Dmail.Domain.Repositories;

public class AccountRepository : BaseRepository
{
    public AccountRepository(DmailDbContext dbContext) : base(dbContext)
    {
        
    }

    public Response Add(Account newAccount)
    {
        DbContext.Accounts.Add(newAccount);
        return SaveChanges();
    }

    public Response Delete(int idToDelete)
    {
        var accountToDelete = DbContext.Accounts.Find(idToDelete);
        if (accountToDelete is null) return Response.NotFound;
        
        DbContext.Accounts.Remove(accountToDelete);

        return SaveChanges();
    }

    public Response Update(Account updatedAccount, int idToUpdate)
    {
        var accountToUpdate = DbContext.Accounts.Find(idToUpdate);
        if (accountToUpdate is null) return Response.NotFound;

        accountToUpdate.Password = updatedAccount.Password;
        accountToUpdate.Email = updatedAccount.Email;
        accountToUpdate.Deactivated = updatedAccount.Deactivated;
        
        return SaveChanges();
    }
}