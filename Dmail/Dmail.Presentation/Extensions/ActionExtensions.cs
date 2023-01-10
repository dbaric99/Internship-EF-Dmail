using Dmail.Presentation.Abstractions;
using Dmail.Presentation.Actions;
using Dmail.Presentation.Constants;
using Dmail.Presentation.Helpers;

namespace Dmail.Presentation.Extensions;

public static class ActionExtensions
{
    public static void SetIndices(this IEnumerable<IAction> actions)
    {
        var i = 0;
        foreach (var action in actions)
            action.MenuIndex = ++i;
    }

    public static void PrintActionsAndOpen(this IList<IAction> actions)
    {
        var shouldExit = false;

        do
        {
            PrintMenu(actions);
            var isValid = int.TryParse(Console.ReadLine(), out var actionIndex);

            if (!isValid)
            {
                MessageHelper.PrintErrorMessage(MessageConstants.INVALID_INPUT);
                continue;
            }

            var selectedAction = actions.FirstOrDefault(a => a.MenuIndex == actionIndex);

            if (selectedAction is null)
            {
                MessageHelper.PrintWarningMessage(MessageConstants.INVALID_ACTION);
                continue;
            }
            
            selectedAction.Open();
            shouldExit = selectedAction is ExitMenuAction;
            
        } while (!shouldExit);
    }

    public static void PrintMenu(IList<IAction> actions)
    {
        foreach (var action in actions)
        {
            Console.WriteLine($"{action.MenuIndex}. {action.Name}");
        }
        Console.Write("Input your choice: ");
    }
    
    /*public static void PrintActionsAndOpen(this IList<IAction> actions)
    {
        const string INVALID_INPUT_MSG = "Please type in number!";
        const string INVALID_ACTION_MSG = "Please select valid action!";


        var isExitSelected = false;
        do
        {
            PrintActions(actions);

            var isValidInput = int.TryParse(Console.ReadLine(), out var actionIndex);
            if (!isValidInput)
            {
                PrintErrorMessage(INVALID_INPUT_MSG);
                continue;
            }

            var action = actions.FirstOrDefault(a => a.MenuIndex == actionIndex);
            if (action is null)
            {
                PrintErrorMessage(INVALID_ACTION_MSG);
                continue;
            }

            action.Open();

            isExitSelected = action is ExitMenuAction;
        } while (!isExitSelected);
    }*/
}