using Dmail.Presentation.Abstractions;

namespace Dmail.Presentation.Actions.User;

public class UserAction : BaseMenuAction
{
    public UserAction(IList<IAction> actions) : base(actions)
    {
        Name = "Authentication";
    }

    public override void Open()
    {
        Console.WriteLine("Authentication");
        base.Open();
    }
}