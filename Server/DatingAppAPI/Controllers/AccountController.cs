using System.Security.Cryptography;
using System.Text;
using DatingAppAPI.Data;
using DatingAppAPI.DTOs;
using DatingAppAPI.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAppAPI.Controllers
{
    
    public class AccountController(DataContext context) : BaseApiController
    {
        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto){

            if(await UserExists(registerDto.Username)) return BadRequest("Username Already Taken");

            using var hmac = new HMACSHA512();
            var user = new AppUser{
                Username = registerDto.Username.ToLower(),
                PasswordHashed = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalted = hmac.Key,
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        private async Task<bool> UserExists(string username){
            return await context.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower());
        }

        [HttpPost("login")]
        public async Task<ActionResult<AppUser>> Login(LoginDto loginDto){
            var user = await context.Users.FirstOrDefaultAsync(u => u.Username == loginDto.UserName.ToLower());

            if(user == null) return Unauthorized("Inavlid Username");

            var hmac = new HMACSHA512(user.PasswordSalted);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for(int i = 0; i < computedHash.Length; i++){
                if(computedHash[i] != user.PasswordHashed[i]){
                    return Unauthorized("Invalid Password");
                }
            }
            return user;

        }
    }

    
}
