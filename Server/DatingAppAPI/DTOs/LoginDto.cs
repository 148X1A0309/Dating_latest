using System;
using System.ComponentModel.DataAnnotations;

namespace DatingAppAPI.DTOs;

public class LoginDto
{
    [Required]
    public required string UserName { get; set;}
    [Required]
    public required string Password { get; set;}


}
