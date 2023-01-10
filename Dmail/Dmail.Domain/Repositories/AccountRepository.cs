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
        //TODO check for duplicates
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

    public Account? FindByEmail(string email)
    {
        if (!DbContext.Accounts.Any()) return null;
        var account = DbContext.Accounts.First(a => a.Email == email);
        return account;
    }

    public void PrintAllAccounts()
    {
        foreach (var account in DbContext.Accounts)
        {
            Console.WriteLine("Email: " + account.Email + " Deactivated: " + account.Deactivated);
        }
    }
}