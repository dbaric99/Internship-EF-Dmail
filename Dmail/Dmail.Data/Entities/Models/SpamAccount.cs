namespace Dmail.Data.Entities.Models;

public class SpamAccount
{
    public int AccountId { get; set; }
    public Account Account { get; set; }
    public int AccountSpamId { get; set; }
    public Account AccountSpam { get; set; }

    public SpamAccount()
    {
        
    }
}