using Dmail.Data.Entities.Models;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Helpers;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.Profile;

public class ProfileSettingsAction : IAction
{
    private readonly AccountRepository _accountRepository;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Profile Settings";

    public ProfileSettingsAction(AccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
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
        
        PrintAccounts(accounts, authUser.Id);
    }

    private void PrintAccounts(List<Account> accounts, int authUserId)
    {
        for (var i = 1; i < accounts.Count; i++)
        {
            var currentAccount = accounts[i - 1];
            Console.WriteLine($"{i} - {currentAccount.Email} {(_accountRepository.CheckIfSpamForUser(authUserId, currentAccount.Id) ? "- spam" : "")}");
        }
    }
}