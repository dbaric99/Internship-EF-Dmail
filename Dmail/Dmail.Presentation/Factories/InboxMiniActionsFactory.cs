using Dmail.Data.Entities.Models;
using Dmail.Domain.Factories;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Actions;
using Dmail.Presentation.Actions.Inbox;
using Dmail.Presentation.Extensions;

namespace Dmail.Presentation.Factories;

public class InboxMiniActionsFactory
{
    public static IList<IAction> CreateActions(MailType mail)
    {
        var actions = new List<IAction>
        {
            new MarkUnreadAction(RepositoryFactory.Create<EmailRepository>(), RepositoryFactory.Create<EventRepository>(), mail),
            new MarkSpamAction(RepositoryFactory.Create<SpamAccountRepository>(), mail),
            new DeleteMailAction(RepositoryFactory.Create<EmailRepository>(), RepositoryFactory.Create<EventRepository>(), mail),
            new RespondToMailAction(RepositoryFactory.Create<EmailRepository>(), RepositoryFactory.Create<EventRepository>(), mail),
            new ExitMenuAction()
        };
        
        actions.SetIndices();

        return actions;
    }
}