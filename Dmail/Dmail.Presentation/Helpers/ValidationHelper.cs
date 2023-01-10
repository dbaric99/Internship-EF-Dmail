namespace Dmail.Presentation.Helpers;

public static class ValidationHelper
{
    public static bool EmailValidation(string email)
    {
        if (!email.Contains('@'))
            return false;

        var username = email.Split('@')[0];
        var domain = email.Split('@')[1];
        
        if (username.Length < 1)
            return false;

        if (!domain.Contains('.'))
            return false;

        return domain.Split('.')[0].Length >= 2 && domain.Split('.')[1].Length >= 3;
    }
}