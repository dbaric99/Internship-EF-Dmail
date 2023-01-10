namespace Dmail.Presentation.Helpers;

public static class MessageHelper
{
    public static void PrintErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Errror! " + message);
        Console.ResetColor();
        Thread.Sleep(3000);
        Console.Clear();
    }

    public static void PrintSuccessMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Success! " + message);
        Console.ResetColor();
        Thread.Sleep(3000);
        Console.Clear();
    }

    public static void PrintWarningMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Warning! " + message);
        Console.ResetColor();
    }
}