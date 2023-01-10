using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Actions;
using Dmail.Presentation.Actions.Dashboard;
using Dmail.Presentation.Extensions;

namespace Dmail.Presentation.Factories;

public class DashboardActionsFactory
{
    public static DashboardAction Create()
    {
        var actions = new List<IAction>
        {
            new ExitMenuAction()
        };

        return new DashboardAction(actions);
    }
}