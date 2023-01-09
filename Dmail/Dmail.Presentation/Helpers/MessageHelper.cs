namespace Dmail.Presentation.Helpers;

public class MessageHelper
{
    public void PrintErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Errror! " + message);
        Console.ResetColor();
    }

    public void PrintSuccessMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Success! " + message);
        Console.ResetColor();
    }

    public void PrintWarningMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Warning! " + message);
        Console.ResetColor();
    }
}