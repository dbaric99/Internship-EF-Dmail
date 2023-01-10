using Dmail.Domain.Factories;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Actions;
using Dmail.Presentation.Actions.Authentication;
using Dmail.Presentation.Actions.User;
using Dmail.Presentation.Extensions;

namespace Dmail.Presentation.Factories;

public class AuthenticationActionsFactory
{
    public static AuthenticationAction Create()
    {
        var actions = new List<IAction>
        {
            new LoginAction(RepositoryFactory.Create<AccountRepository>()),
            new RegisterAction(RepositoryFactory.Create<AccountRepository>()),
            new ExitMenuAction()
        };

        return new AuthenticationAction(actions);
    }
}