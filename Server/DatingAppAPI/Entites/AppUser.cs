using System;

namespace DatingAppAPI.Entites;

public class AppUser
{
    public int Id {get; set;}
    public required string Username { get; set; }
    public required byte[] PasswordHashed { get; set; }
    public required byte[] PasswordSalted { get; set; }

}
