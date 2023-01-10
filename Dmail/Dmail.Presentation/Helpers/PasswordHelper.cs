using System.Security.Cryptography;
using System.Text;
using UtilityLibrary;

namespace Dmail.Presentation.Helpers;

public static class PasswordHelper
{
    public static string PasswordInput()
    {
        Console.TreatControlCAsInput = true;
        var password = "";
        ConsoleKeyInfo key;

        do
        {

            key = Console.ReadKey(true);
            if (!char.IsControl(key.KeyChar) && key.Key != ConsoleKey.Spacebar)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                break;
            }

        } while (true);

        return PasswordLibrary.EncryptPassword(password);
    }
}