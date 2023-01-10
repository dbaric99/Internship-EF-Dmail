namespace Dmail.Presentation.Helpers;

public static class InputHelper
{
    public static int NumberInput(string message, int minVal, int maxVal)
    {
        Console.Write($"\n{message}: ");
        var success = int.TryParse(Console.ReadLine(), out var choice);
        switch (success)
        {
            case true when choice >= minVal && choice <= maxVal:
                return choice;
            case false:
                MessageHelper.PrintErrorMessage("Choice must be a number!");
                return 0;
            default:
                MessageHelper.PrintErrorMessage("No action for provided input!");
                return 0;
        }
    }
}