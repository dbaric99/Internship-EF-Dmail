using Dmail.Domain.Factories;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Helpers;

namespace Dmail.Presentation.Actions.Admin;

public class AdminAction : IAction
{
    private readonly AccountRepository _accountRepository;
    private readonly AdminRepository _adminRepository;

    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Administration";

    public AdminAction(AccountRepository accountRepository, AdminRepository adminRepository)
    {
        _accountRepository = accountRepository;
        _adminRepository = adminRepository;
    }

    public void Open()
    {
        Console.Write("Admin password: ");
        var password = PasswordHelper.PasswordInput();
        if (password != _adminRepository.GetAdminEncryptedPassword())
        {
            MessageHelper.PrintErrorMessage("Wrong password");
            Thread.Sleep(30000);
            return;
        }
        Console.WriteLine(new String('-',25));

        var disableAccountAction = new DisableAccountAction(RepositoryFactory.Create<AccountRepository>());
        disableAccountAction.Open();
    }
}