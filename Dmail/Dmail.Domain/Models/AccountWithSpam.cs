using Dmail.Data.Entities.Models;

namespace Dmail.Domain.Models;

public class AccountWithSpam
{
    public Account UserAccount { get; set; }
    public IEnumerable<Account> SpamAccounts { get; set; }

    public AccountWithSpam(Account userAccount, List<Account> spamAccounts)
    {
        UserAccount = userAccount;
        SpamAccounts = spamAccounts;
    }
}