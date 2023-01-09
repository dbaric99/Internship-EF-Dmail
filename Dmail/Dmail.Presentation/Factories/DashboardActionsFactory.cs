using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Actions;
using Dmail.Presentation.Extensions;

namespace Dmail.Presentation.Factories;

public class DashboardActionsFactory
{
    public static IList<IAction> CreateActions()
    {
        var actions = new List<IAction>
        {
            new ExitMenuAction()
        };
        
        actions.SetIndices();

        return actions;
    }
}