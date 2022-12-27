namespace Dmail.Data.Entities.Models;

public class Admin : User
{
    public string Role { get; set; } = "admin";
    
    public Admin() : base()
    {
            
    }
}