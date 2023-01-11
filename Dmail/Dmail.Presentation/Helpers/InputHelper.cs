using Dmail.Domain.Repositories;

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

    public static List<string> EmailReceiversInput(string receivers, AccountRepository accountRepository)
    {
        var receiversList = new List<string>();

        if (!receivers.Contains(','))
        {
            if (ValidationHelper.EmailValidation(receivers))
            {
                receiversList.Add(receivers);
            }
        }
        else if (receivers.Contains(','))
        {
            foreach (var receiver in receivers.Split(','))
            {
                if(ValidationHelper.EmailValidation(receiver))
                    receiversList.Add(receiver);
            }
        }

        foreach (var recEmail in receiversList)
        {
            if (accountRepository.FindByEmail(recEmail) is null)
            {
                MessageHelper.PrintErrorMessage($"Email {recEmail} is not valid!");
                receiversList.Remove(recEmail);
            }
        }

        return receiversList;
    }

    public static bool IsInputConforming(string providedInput)
    {
        return providedInput.Trim().ToLower() == "y";
    }
}