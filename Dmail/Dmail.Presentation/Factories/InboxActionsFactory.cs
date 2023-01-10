using Dmail.Domain.Factories;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Actions;
using Dmail.Presentation.Actions.Inbox;
using Dmail.Presentation.Extensions;

namespace Dmail.Presentation.Factories;

public class InboxActionsFactory
{
    public static IList<IAction> CreateActions()
    {
        var actions = new List<IAction>
        {
            new ReadMailAction(RepositoryFactory.Create<EmailRepository>(), RepositoryFactory.Create<EventRepository>()),
            new UnReadMailAction(RepositoryFactory.Create<EmailRepository>(), RepositoryFactory.Create<EventRepository>()),
            new MailBySenderAction(RepositoryFactory.Create<EmailRepository>(), RepositoryFactory.Create<EventRepository>()),
            new ExitMenuAction()
        };
        
        actions.SetIndices();

        return actions;
    }
}