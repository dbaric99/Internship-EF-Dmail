using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Actions;
using Dmail.Presentation.Extensions;

namespace Dmail.Presentation.Factories;

public class MainMenuFactory
{
    public static IList<IAction> CreateActions()
    {
        var actions = new List<IAction>
        {
            AuthenticationActionsFactory.Create(),
            DashboardActionsFactory.Create(),
            new ExitMenuAction(),
        };
        
        actions.SetIndices();

        return actions;
    }
}