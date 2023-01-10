using Dmail.Presentation.Extensions;

namespace Dmail.Presentation.Abstractions;

public class BaseMenuAction : IMenuAction
{
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Action";
    public IList<IAction> Actions { get; set; }

    public BaseMenuAction(IList<IAction> actions)
    {
        actions.SetIndices();
        Actions = actions;
    }

    public virtual void Open()
    {
        Actions.PrintActionsAndOpen();
    }
}