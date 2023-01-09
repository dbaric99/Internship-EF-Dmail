using Dmail.Presentation.Abstractions;

namespace Dmail.Presentation.Actions;

public class ExitMenuAction : IAction
{
    public int MenuIndex { get; set; }
    public string Name { get; set; } = "Exit";

    public void Open() { }
}