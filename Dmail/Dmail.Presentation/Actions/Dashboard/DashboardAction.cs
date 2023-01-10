using Dmail.Presentation.Abstractions;

namespace Dmail.Presentation.Actions.Dashboard;

public class DashboardAction : BaseMenuAction
{
    public DashboardAction(IList<IAction> actions) : base(actions)
    {
        Name = "Dashboard";
    }

    public override void Open()
    {
        Console.WriteLine("Dashboard");
        base.Open();
    }
}