using System.Runtime.Caching;
using Dmail.Domain.Enums;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Helpers;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.User;

public class LoginAction : IAction
{
    private readonly AccountRepository _accountRepository;
    private readonly CacheService _cacheService = new();

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "User Login";

    public LoginAction(AccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public void Open()
    {
        Console.Write("Email: ");
        var email = Console.ReadLine();

        var targetUser = _accountRepository.FindByEmail(email);
        if (targetUser is null)
        {
            MessageHelper.PrintErrorMessage($"Account with email: {email} not found");
            return;
        }

        if (targetUser.Deactivated)
        {
            MessageHelper.PrintErrorMessage("This account is disabled, please contact admin about re-activation of your account");
            return;
        }
            
        Console.Write("Password: ");
        var password = PasswordHelper.PasswordInput();
        if (password != targetUser.Password)
        {
            MessageHelper.PrintErrorMessage($"Password does not match with user: {email}");
            Thread.Sleep(30000);
            return;
        }

        _cacheService.SetData("authUser", targetUser);
    }
}