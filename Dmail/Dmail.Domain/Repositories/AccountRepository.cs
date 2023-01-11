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

    public Account? FindByEmail(string email)
    {
        if (!DbContext.Accounts.Any()) return null;
        var account = DbContext.Accounts.FirstOrDefault(a => a.Email == email);
        return account;
    }

    public List<Account> GetAllAccounts()
    {
        return DbContext.Accounts.ToList();
    }

    public List<Account> GetAllUsersWithActivity(int authUserId)
    {
        var authUser = DbContext.Accounts.Find(authUserId);

        var accounts = new List<Account>();

        foreach (var email in DbContext.Emails)
        {
            if (email.SenderId == authUserId)
            {
                accounts.Add(email.Receiver);
            }           
            else if (email.ReceiverId == authUserId)
            {
                accounts.Add(email.Receiver);
            }
        }

        foreach (var ev in DbContext.Events)
        {
            if (ev.SenderId == authUserId)
            {
                accounts.AddRange(ev.EventAttendance.Select(attendees => attendees.Attendee));
            }
            else
            {
                foreach (var attendees in ev.EventAttendance)
                {
                    if (attendees.AttendeeId != authUserId) continue;
                    accounts.AddRange(from at in ev.EventAttendance where at.AttendeeId != authUserId select at.Attendee);
                    accounts.Add(ev.Sender);
                }
            }
        }

        return accounts.Distinct().ToList();
    }

    public bool CheckIfSpamForUser(int authUserId, int accountId)
    {
        return Enumerable.Any(DbContext.SpamAccounts, spam => spam.AccountId == authUserId && spam.AccountSpamId == accountId);
    }

    public Response AccountAdministration(int accountId)
    {
        var accountToUpdate = DbContext.Accounts.Find(accountId);
        if (accountToUpdate is null) return Response.NotFound;
        
        accountToUpdate.Deactivated = !accountToUpdate.Deactivated;
        
        return SaveChanges();
    }
}