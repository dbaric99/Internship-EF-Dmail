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
        if (!ValidationHelper.EmailValidation(email))
        {
            MessageHelper.PrintErrorMessage("Wrong email format! Email should look like: example@domain.com");
            return;
        }

        var targetUser = _accountRepository.FindByEmail(email);
        if (targetUser is null)
        {
            MessageHelper.PrintErrorMessage($"Account with email: {email} not found");
            return;
        }
            
        Console.Write("Password: ");
        var password = PasswordHelper.PasswordInput();
        if (password != targetUser.Password)
        {
            MessageHelper.PrintErrorMessage($"Password does not match with user: {email}");
            return;
        }

        _cacheService.SetData("authUser", targetUser);
    }
}