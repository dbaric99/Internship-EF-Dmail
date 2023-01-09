using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Actions;
using Dmail.Presentation.Extensions;

namespace Dmail.Presentation.Factories;

public class UserActionsFactory
{
    public static IList<IAction> Create()
    {
        var actions = new List<IAction>
        {
            new ExitMenuAction()
        };
        
        actions.SetIndices();

        return actions;
    }
}