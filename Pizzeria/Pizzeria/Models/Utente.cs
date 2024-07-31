using Microsoft.AspNetCore.Identity;

public class Utente : IdentityUser
{
    public string Nome { get; set; }
    public string Password { get; set; }
}