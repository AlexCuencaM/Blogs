using Blogs.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUsersService usersService) : ControllerBase
    {
        private readonly IUsersService _usersService = usersService; 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _usersService.GetUsersAsync());
        }
    }
}
