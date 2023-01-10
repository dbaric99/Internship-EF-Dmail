using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;

namespace Dmail.Presentation.Actions.User;

public class RegisterAction : IAction
{
    private readonly AccountRepository _accountRepository;
    
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Register new user";

    public RegisterAction(AccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public void Open()
    {
        
    }
}