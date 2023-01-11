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

    private List<Account> GetSpamAccountsForUser(int userId)
    {
        return (from spamAcc in DbContext.SpamAccounts where spamAcc.AccountId == userId select spamAcc.AccountSpam).ToList();
    }

    public Tuple<List<Email>, List<Event>> GetSpamMail(int userId)
    {
        var spamAccountsForUser = GetSpamAccountsForUser(userId);
        if (spamAccountsForUser is null) return null;

        var spamEmails = (from email in DbContext.Emails let isSpam = spamAccountsForUser.Where(spam => spam.Id == email.SenderId) where email.ReceiverId == userId && isSpam is not null select email).ToList();

        var spamEvents = (from ev in DbContext.Events let isSpam = spamAccountsForUser.FirstOrDefault(spam => spam.Id == ev.SenderId) let isInInbox = ev.EventAttendance.FirstOrDefault(at => at.AttendeeId == userId) where isInInbox is not null && isSpam is not null select ev).ToList();

        return Tuple.Create(spamEmails, spamEvents);
    }

    public Response ChangeIfSpam(int authUserId, int spamAccountId)
    {
        SpamAccount choosenSpamAccount = new SpamAccount();
        foreach (var spamAcc in DbContext.SpamAccounts)
        {
            if (spamAcc.AccountId == authUserId && spamAcc.AccountSpamId == spamAccountId)
            {
                choosenSpamAccount = spamAcc;
            }
        }

        if (choosenSpamAccount is null) return Response.NotFound;
        
        DbContext.SpamAccounts.Remove(choosenSpamAccount);

        return SaveChanges();
    }
}