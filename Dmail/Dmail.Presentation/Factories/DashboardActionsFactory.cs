using Dmail.Domain.Factories;
using Dmail.Domain.Repositories;
using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Actions;
using Dmail.Presentation.Actions.Dashboard;
using Dmail.Presentation.Actions.Inbox;
using Dmail.Presentation.Actions.Outbox;
using Dmail.Presentation.Actions.Profile;
using Dmail.Presentation.Extensions;

namespace Dmail.Presentation.Factories;

public class DashboardActionsFactory
{
    public static DashboardAction Create()
    {
        var actions = new List<IAction>
        {
            new InboxAction(RepositoryFactory.Create<EmailRepository>(), RepositoryFactory.Create<EventRepository>()),
            new OutboxAction(RepositoryFactory.Create<EmailRepository>(), RepositoryFactory.Create<EventRepository>()),
            new SpamAction(RepositoryFactory.Create<EmailRepository>(), RepositoryFactory.Create<EventRepository>(), RepositoryFactory.Create<SpamAccountRepository>()),
            new NewMailAction(RepositoryFactory.Create<EmailRepository>(), RepositoryFactory.Create<AccountRepository>()),
            new NewEventAction(RepositoryFactory.Create<EventRepository>(), RepositoryFactory.Create<AccountRepository>(), RepositoryFactory.Create<AttendanceRepository>()),
            new ProfileSettingsAction(RepositoryFactory.Create<AccountRepository>(), RepositoryFactory.Create<SpamAccountRepository>()),
            new SignOutAction(RepositoryFactory.Create<AccountRepository>()),
            new ExitMenuAction()
        };

        return new DashboardAction(actions);
    }
}