using DatingAppAPI.Data;
using DatingAppAPI.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAppAPI.Controllers
{
    public class UsersController(DataContext context) : BaseApiController
    {
        [HttpGet]
        public async Task <ActionResult<IEnumerable<AppUser>>> GetUsers(){
            var users = await context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id){
            var user = await context.Users.FindAsync(id);
            if(user == null) return NotFound();
            return Ok(user);


        }
    }
}
