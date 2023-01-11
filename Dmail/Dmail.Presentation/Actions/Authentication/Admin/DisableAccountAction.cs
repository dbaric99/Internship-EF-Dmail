using Dmail.Domain.Enums;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Helpers;

namespace Dmail.Presentation.Actions.Admin;

public class DisableAccountAction : IAction
{
    private readonly AccountRepository _accountRepository;
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Deactivate/Reactivate accounts";

    public DisableAccountAction(AccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public void Open()
    {
        var accounts = _accountRepository.GetAllAccounts();

        for (var i = 1; i < accounts.Count; i++)
        {
            var current = accounts[i - 1];
            Console.WriteLine($"{i} - {current.Email} - {(current.Deactivated ? "Deactivated" : "Active")}");
        }

        var accountToUpdate = InputHelper.NumberInput("\nAccount: ", 1, accounts.Count);

        if (accountToUpdate == 0) return;

        var res = _accountRepository.AccountAdministration(accountToUpdate);
        
        if(res == Response.NotFound)
            MessageHelper.PrintErrorMessage("Account not found!");
        else if(res == Response.Success)
            MessageHelper.PrintSuccessMessage("Account successfully updated!");
    }
}