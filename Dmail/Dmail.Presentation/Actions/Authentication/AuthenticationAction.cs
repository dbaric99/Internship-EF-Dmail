using Dmail.Presentation.Abstractions;

namespace Dmail.Presentation.Actions.Authentication;

public class AuthenticationAction : BaseMenuAction
{
    public AuthenticationAction(IList<IAction> actions) : base(actions)
    {
        Name = "Authentication";
    }

    public override void Open()
    {
        Console.WriteLine(new String('-',25));
        Console.WriteLine("Authentication");
        base.Open();
    }
}