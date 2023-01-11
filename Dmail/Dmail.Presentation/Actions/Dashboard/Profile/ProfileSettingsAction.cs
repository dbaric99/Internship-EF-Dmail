using Dmail.Data.Entities.Models;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Helpers;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.Profile;

public class ProfileSettingsAction : IAction
{
    private readonly AccountRepository _accountRepository;
    private readonly SpamAccountRepository _spamAccountRepository;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Profile Settings";

    public ProfileSettingsAction(AccountRepository accountRepository, SpamAccountRepository spamAccountRepository)
    {
        _accountRepository = accountRepository;
        _spamAccountRepository = spamAccountRepository;
    }

    public void Open()
    {
        var authUser = _cacheService.GetData<Account>("authUser");

        var accounts = _accountRepository.GetAllUsersWithActivity(authUser.Id);

        if (accounts.Count == 0)
        {
            MessageHelper.PrintErrorMessage("There are no accounts that interacted with user!");
            return;
        }
        
        Console.Write("\nFilter by spam (y/n): ");
        var isSpam = InputHelper.IsInputConforming(Console.ReadLine());
        
        PrintAccountsAndSelect(accounts, authUser.Id, isSpam);
    }

    private void PrintAccountsAndSelect(List<Account> accounts, int authUserId, bool displaySpam)
    {
        var spamAccounts = new List<Account>();
        var nonSpamAccounts = new List<Account>();

        foreach (var account in accounts)
        {
            if (displaySpam && _accountRepository.CheckIfSpamForUser(authUserId, account.Id))
                spamAccounts.Add(account);
            else
                nonSpamAccounts.Add(account);
        }

        var len = displaySpam ? spamAccounts.Count : nonSpamAccounts.Count;
        for (var i = 1; i < len; i++)
        {
            var currentAccount = displaySpam ? spamAccounts[i - 1] : nonSpamAccounts[i-1];
            Console.WriteLine($"{i} - {currentAccount.Email}");
        }
        
        var maxVal = displaySpam ? spamAccounts.Count : nonSpamAccounts.Count;
        var chosenAccountIndex = InputHelper.NumberInput($"\nSelect an account you want to mark {(displaySpam ? "non spam" : "spam")}: ", 1, maxVal);

        if (chosenAccountIndex == 0) return;

        var choosenAccount = displaySpam ? spamAccounts[chosenAccountIndex] : nonSpamAccounts[chosenAccountIndex];

        _spamAccountRepository.ChangeIfSpam(authUserId, choosenAccount.Id);
    }
}