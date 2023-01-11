using Dmail.Data.Entities.Models;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Extensions;
using Dmail.Presentation.Factories;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.Profile;

public class SignOutAction : IAction
{
    private readonly AccountRepository _accountRepository;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Sign out";

    public SignOutAction(AccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public void Open()
    {
        _cacheService.RemoveData("authUser");
        
        var mainMenuActions = MainMenuFactory.CreateActions();
        mainMenuActions.PrintActionsAndOpen();
    }
}