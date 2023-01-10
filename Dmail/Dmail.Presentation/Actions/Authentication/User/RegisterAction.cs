using Dmail.Data.Entities.Models;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Helpers;
using Dmail.Presentation.Services;

namespace Dmail.Presentation.Actions.User;

public class RegisterAction : IAction
{
    private readonly AccountRepository _accountRepository;
    private readonly CacheService _cacheService = new();
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Register new user";

    public RegisterAction(AccountRepository accountRepository)
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

        if (_accountRepository.FindByEmail(email) is not null)
        {
            MessageHelper.PrintErrorMessage("User with that email address already exists!");
            return;
        }
        
        Console.Write("Password: ");
        var password = PasswordHelper.PasswordInput();
        Console.WriteLine("Repeat password: ");
        var repeatedPassword = PasswordHelper.PasswordInput();

        if (password != repeatedPassword)
        {
            MessageHelper.PrintErrorMessage("Passwords do not match!");
            return;
        }
        if (password.Length == 0)
        {
            MessageHelper.PrintWarningMessage("Account not secure!");
        }

        var newUser = new Data.Entities.Models.Account(email, password);
        
        //TODO this next line is null, check why
        _accountRepository.Add(newUser);
        _cacheService.SetData("authUser", newUser);
    }
}